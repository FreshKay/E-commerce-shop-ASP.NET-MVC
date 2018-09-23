using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string name)
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            return View();
        }
    }
}