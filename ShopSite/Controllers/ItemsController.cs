using PagedList;
using PagedList.Mvc;
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

        public ActionResult List(string name, int? page)
        {
            var category = db.Categories.Include("Items").Where(k => k.CategoryName.ToUpper() == name.ToUpper()).Single();
            var items = category.Items.ToList();

            return View(items.ToPagedList(page ?? 1, 3));
        }

        public ActionResult SearchList(string searchQuery, int? page)
        {
            var itemsDb = from s in db.Items select s;

            if (!String.IsNullOrEmpty(searchQuery))
            {
                itemsDb = itemsDb.Where(s => (searchQuery == null || s.ItemName.ToLower().Contains(searchQuery.ToLower()) ||
                        s.ItemProducer.ToLower().Contains(searchQuery.ToLower())) && s.Available);
            }

            var items = itemsDb.ToList();

            return View(items.ToPagedList(page ?? 1, 8));
        }

        public ActionResult Details(int id)
        {
            var item = db.Items.Find(id);
            return View(item);
        }       

    }
}