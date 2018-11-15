using NLog;
using ShopSite.DAL;
using ShopSite.Infrastructure;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ItemsContext db = new ItemsContext();

        public ActionResult Index()
        {
            var category = db.Categories.ToList();

            var best = db.Items.Where(a => a.Available && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(4).ToList();

            ICacheProvider cache = new DefaultCacheProvider();
            List<Item> newOnes;
            if (cache.IsSet(Consts.NewsCacheKey))
            {
                newOnes = cache.Get(Consts.NewsCacheKey) as List<Item>;
            }
            else
            {
                newOnes = db.Items.Where(a => a.Available).OrderByDescending(a => a.AddDate).Take(4).ToList();
                cache.Set(Consts.NewsCacheKey, newOnes, 60);
            }
          

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

       

        public ActionResult ItemSuggestions(string term)
        { 
            var items = db.Items.Where(a => a.Available && a.ItemName.ToLower().Contains(term.ToLower())).Take(5).Select(a => new { label = a.ItemName });

            return Json(items, JsonRequestBehavior.AllowGet);
        }

    }
}