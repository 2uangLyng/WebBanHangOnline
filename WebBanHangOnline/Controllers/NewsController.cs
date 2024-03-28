using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Services;

namespace WebBanHangOnline.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext dbContext;

        public NewsController()
        {
            dbContext = DbContextSingleton.Instance.GetDbContext();
        }
        // GET: News
        public ActionResult Index(int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = dbContext.News.OrderByDescending(x=>x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Detail(int id)
        {
            var item = dbContext.News.Find(id);
            return View(item);
        }
        public ActionResult Partial_News_Home()
        {
            var items = dbContext.News.Take(3).ToList();
            return PartialView(items);
        }
    }
}