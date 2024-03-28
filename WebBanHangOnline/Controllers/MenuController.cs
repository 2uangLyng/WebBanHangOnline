using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Services;

namespace WebBanHangOnline.Controllers
{
    public class MenuController : Controller
    {

        private ApplicationDbContext dbContext;

        public MenuController()
        {
            dbContext = DbContextSingleton.Instance.GetDbContext();
        }
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTop()
        {
            var items = dbContext.Categories.OrderBy(x=>x.Position).ToList();
            return PartialView("_MenuTop", items);
        }

        public ActionResult MenuProductCategory()
        {
            var items = dbContext.ProductCategories.ToList();
            return PartialView("_MenuProductCategory", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = dbContext.ProductCategories.ToList();
            return PartialView("_MenuLeft", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = dbContext.ProductCategories.ToList();
            return PartialView("_MenuArrivals", items);
        }

    }
}