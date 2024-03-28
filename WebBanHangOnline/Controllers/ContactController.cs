using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Services;

namespace WebBanHangOnline.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext dbContext;

        public ContactController()
        {
            dbContext = DbContextSingleton.Instance.GetDbContext();
        }

        // GET: Contact
        public ActionResult Index(string id)
        {
            return View();
        }
    }
}