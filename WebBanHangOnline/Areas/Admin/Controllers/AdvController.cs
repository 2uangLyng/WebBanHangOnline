using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Services;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class AdvController : Controller
    {
        private ApplicationDbContext dbContext;

        public AdvController()
        {
            dbContext = DbContextSingleton.Instance.GetDbContext();
        }
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var items = dbContext.Posts.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Adv model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                dbContext.Advs.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbContext.Advs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Adv model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                dbContext.Advs.Attach(model);
                dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbContext.Advs.Find(id);
            if (item != null)
            {
                dbContext.Advs.Remove(item);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

       
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = dbContext.Advs.Find(Convert.ToInt32(item));
                        dbContext.Advs.Remove(obj);
                        dbContext.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}