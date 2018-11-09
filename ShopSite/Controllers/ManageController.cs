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
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ItemsContext db = new ItemsContext();

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
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

        // GET: Manage
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

        public ActionResult OrderList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrders;

            // Dla administratora zwracamy wszystkie zamowienia
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderState ChangeOrderState(Order order)
        {
            Order orderToChange = db.Orders.Find(order.OrderId);
            orderToChange.OrderState = order.OrderState;
            db.SaveChanges();

            return order.OrderState;
        }

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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddItem (EditItemViewModel model, HttpPostedFileBase file)
        {
            if (model.Item.ItemId > 0)
            {
                // modyfikacja kursu
                db.Entry(model.Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddItem", new { confirmation = true });
            }
            else
            {
                // Sprawdzenie, czy użytkownik wybrał plik
                if (file != null && file.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {
                        // Generowanie pliku
                        var fileExt = Path.GetExtension(file.FileName);
                        var filename = Guid.NewGuid() + fileExt;

                        var path = Path.Combine(Server.MapPath(AppConfig.PicturesFolder), filename);
                        file.SaveAs(path);

                        model.Item.ItemPicture = filename;
                        model.Item.AddDate = DateTime.Now;

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

        [Authorize(Roles = "Admin")]
        public ActionResult HideItem(int itemId)
        {
            var item = db.Items.Find(itemId);
            item.Available = false;
            db.SaveChanges();

            return RedirectToAction("AddItem", new { confirmation = true });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowItem(int itemId)
        {
            var item = db.Items.Find(itemId);
            item.Available = true;
            db.SaveChanges();

            return RedirectToAction("AddItem", new { confirmation = true });
        }

    }
}