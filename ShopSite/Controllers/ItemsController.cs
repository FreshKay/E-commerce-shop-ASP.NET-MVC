using ShopSite.DAL;
using ShopSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Controllers
{
    public class ItemsController : Controller
    {
        private ItemsContext db = new ItemsContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string name)
        {
            var category = db.Categories.Include("Items").Where(k => k.CategoryName.ToUpper() == name.ToUpper()).Single();
            var items = category.Items.ToList();

            var category_2 = db.Categories.ToList();

            var vi = new HomeViewModel()
            {
                Categories_2 = items,
                Categories = category_2
            };

            return View(vi);
        }

        public ActionResult Details(string id)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.Categories.ToList();
            return View("_CategoryMenu", categories);
        }
    }
}