using ShopSite.DAL;
using ShopSite.Infrastructure;
using ShopSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Controllers
{
    public class BasketController : Controller
    {
        private BasketManager basketManager;
        private SessionManager sessionManager { get; set; }
        private ItemsContext db;

        public BasketController()
        {
            db = new ItemsContext();
            sessionManager = new SessionManager();
            basketManager = new BasketManager(sessionManager , db);
        }


        public ActionResult Index()
        {
            var basketStatus = basketManager.DownloadBucket();
            var totalPrice = basketManager.GetBucketValues();
            BasketViewModel basketVM = new BasketViewModel()
            {
                BasketStatus = basketStatus,
                PriceSum = totalPrice
            };

            return View(basketVM);
        }

        public ActionResult AddToBasket(int id)
        {
            basketManager.AddToBucket(id);
            return RedirectToAction("Index");
        }

        public int GetBasketQuantity()
        {
            return basketManager.GetBucketQuantity();
        }

        public ActionResult Delete(int itemId)
        {
            int quantityToDelete = basketManager.DeleteFromBucket(itemId);
            int quantity = basketManager.GetBucketQuantity();
            decimal basketValue = basketManager.GetBucketValues();

            var vd = new BasketDeletionViewModel
            {
                BasketQuantity = quantity,
                BasketValue = basketValue,
                QuantityToDelete =  quantityToDelete,
                ItemIdToRemove = itemId
            };

            return Json(vd);
        }

    }
}