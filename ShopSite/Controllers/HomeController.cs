using ShopSite.DAL;
using ShopSite.Models;
using ShopSite.ViewModels;
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
            var category = db.Categories.ToList();

            var best = db.Items.Where(a => a.Available && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(4).ToList();

            var newOnes = db.Items.Where(a => a.Available).OrderByDescending(a => a.AddDate).Take(4).ToList();

            var vm = new HomeViewModel()
            {
                Bestseller = best,
                New = newOnes,
                Categories = category
            };

            return View(vm);
        }

        public ActionResult StaticSites(string nameCat)
        {
           
            return View(nameCat);
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Single()
        {
            return View();
        }

    }
}