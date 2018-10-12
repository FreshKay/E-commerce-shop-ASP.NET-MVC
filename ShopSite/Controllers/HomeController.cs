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
        private ItemsContext db = new ItemsContext();

        public ActionResult Index()
        {
            
            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> category;
            if (cache.IsSet(Consts.CategoriesCacheKey))
            {
                category = cache.Get(Consts.CategoriesCacheKey) as List<Category>;
            }
            else
            {
                category = db.Categories.ToList();
                cache.Set(Consts.CategoriesCacheKey, category, 60);
            }

            List<Item> bestseller;
            if (cache.IsSet(Consts.BessellerCacheKey))
            {
                bestseller = cache.Get(Consts.BessellerCacheKey) as List<Item>;
            }
            else
            {
                bestseller = db.Items.Where(a => a.Available && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(4).ToList();
                cache.Set(Consts.BessellerCacheKey, bestseller, 1);
            }
            
            List<Item> newOnes;
            if (cache.IsSet(Consts.NewsCacheKey))
            {
                newOnes = cache.Get(Consts.NewsCacheKey) as List<Item>;
            }
            else
            {
                newOnes = db.Items.Where(a => a.Available).OrderByDescending(a => a.AddDate).Take(4).ToList();
                cache.Set(Consts.NewsCacheKey, newOnes, 1);
            }
          

            var vm = new HomeViewModel()
            {
                Bestseller = bestseller,
                New = newOnes,
                Categories = category
            };

            return View(vm);
        }

        public ActionResult StaticSites(string nameCat)
        {           
            return View(nameCat);
        }

        public ActionResult ItemsSugestions(string term)
        {
            var items = this.db.Items.Where(a => a.Available && a.ItemName.ToLower().Contains(term.ToLower())).Take(5).Select(a => new { label = a.ItemName });

            return Json(items, JsonRequestBehavior.AllowGet);
        }

    }
}