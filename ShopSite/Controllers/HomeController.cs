using ShopSite.DAL;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Controllers
{
    public class HomeController : Controller
    {
        private ItemsContext db = new ItemsContext();

        public ActionResult Index()
        {
            Category category = new Category { CategoryName = "Socks" };
            db.Categories.Add(category);
            db.SaveChanges();

            return View();
        }
    }
}