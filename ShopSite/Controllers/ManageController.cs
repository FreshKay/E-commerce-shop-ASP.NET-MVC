using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ShopSite.App_Start;
using ShopSite.DAL;
using ShopSite.Infrastructure;
using ShopSite.Models;
using ShopSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ItemsContext db = new ItemsContext();
        private IMailService mailService;

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        public ManageController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // Checks user role
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageViewModel
            {
                Message = message,
                UsersData = user.UsersData
            };

            return View(model);
        }

        // Checks for a proper user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UsersData")]UsersData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UsersData = userData;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // Actionn to change a password
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }


        // Shows order list
        public ActionResult OrderList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrders;

            if (isAdmin)
            {
                userOrders = db.Orders.Include("ItemPosition").OrderByDescending(o => o.AdditionDate).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                userOrders = db.Orders.Where(o => o.UserId == userId).Include("ItemPosition").OrderByDescending(o => o.AdditionDate).ToArray();
            }

            return View(userOrders);
        }

        // Changing state of the order
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderState ChangeOrderState(Order order)
        {
            Order orderToChange = db.Orders.Find(order.OrderId);
            orderToChange.OrderState = order.OrderState;
            db.SaveChanges();

            if (orderToChange.OrderState == OrderState.Executed)
            {
                mailService.OrderSendMessage(orderToChange);
            }

            return order.OrderState;
        }

        //Adding item
        [Authorize(Roles = "Admin")]
        public ActionResult AddItem(int? itemId, bool? confirmation)
        {
            Item item;
            if (itemId.HasValue)
            {
                ViewBag.EditMode = true;
                item = db.Items.Find(itemId);
            }
            else
            {
                ViewBag.EditMode = false;
                item = new Item();
            }

            var result = new EditItemViewModel();
            result.Categories = db.Categories.ToList();
            result.Item = item;
            result.Confirmation = confirmation;

            return View(result);
        }

        // Changing the item
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddItem(EditItemViewModel model, HttpPostedFileBase file)
        {
            if (model.Item.ItemId > 0)
            {
                db.Entry(model.Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddItem", new { confirmation = true });
            }
            else
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {
                        var fileExt = Path.GetExtension(file.FileName);
                        var filename = Guid.NewGuid() + fileExt;

                        var path = Path.Combine(Server.MapPath(AppConfig.PicturesFolder), filename);
                        file.SaveAs(path);

                        model.Item.ItemPicture = filename;
                        model.Item.AddDate = DateTime.Now;
                        model.Item.Available = true;

                        db.Entry(model.Item).State = EntityState.Added;
                        db.SaveChanges();

                        return RedirectToAction("AddItem", new { confirmation = true });
                    }
                    else
                    {
                        var categories = db.Categories.ToList();
                        model.Categories = categories;
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "File not slected.");
                    var categories = db.Categories.ToList();
                    model.Categories = categories;
                    return View(model);
                }
            }
        }

        // Making item unavailable
        [Authorize(Roles = "Admin")]
        public ActionResult HideItem(int itemId)
        {
            var item = db.Items.Find(itemId);
            item.Available = false;
            db.SaveChanges();

            return RedirectToAction("AddItem", new { confirmation = true });
        }

        // Making item available
        [Authorize(Roles = "Admin")]
        public ActionResult ShowItem(int itemId)
        {
            var item = db.Items.Find(itemId);
            item.Available = true;
            db.SaveChanges();

            return RedirectToAction("AddItem", new { confirmation = true });
        }

        // Order confiration via Postal
        [AllowAnonymous]
        public ActionResult OrderConfirmaitonMessage(int orderId, string surname)
        {
            var order = db.Orders.Include("ItemPosition").Include("ItemPosition.Item")
                               .SingleOrDefault(o => o.OrderId == orderId && o.Surname == surname);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.EMail;
            email.From = "";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.ItemPositions = order.ItemPosition;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // Order sending via Postal
        [AllowAnonymous]
        public ActionResult OrderSendMessage(int orderId, string surname)
        {
            var order = db.Orders.Include("ItemPosition").Include("ItemPosition.Item")
                               .SingleOrDefault(o => o.OrderId == orderId && o.Surname == surname);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            OrderSendEmail email = new OrderSendEmail();
            email.To = order.EMail;
            email.From = "";
            email.OrderNumber = order.OrderId;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}