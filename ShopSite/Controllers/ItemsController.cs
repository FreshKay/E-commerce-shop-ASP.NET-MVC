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
            
            return View(items);
        }

        public ActionResult Details(int id)
        {
            var item = db.Items.Find(id);
            return View(item);
        }       

    }
}