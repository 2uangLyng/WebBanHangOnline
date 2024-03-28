using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Services;

namespace WebBanHangOnline.Controllers
{
    public class ArticleController : Controller
    {
        private ApplicationDbContext dbContext;

        public ArticleController()
        {
            dbContext = DbContextSingleton.Instance.GetDbContext();
        }

        // GET: Article
        public ActionResult Index(string alias)
        {
            var item = dbContext.Posts.FirstOrDefault(x => x.Alias == alias);
            return View(item);
        }
    }
}