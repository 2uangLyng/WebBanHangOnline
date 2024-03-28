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
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext dbContext;

        public CategoryController()
        {
            dbContext = DbContextSingleton.Instance.GetDbContext();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = dbContext.Categories;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                dbContext.Categories.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbContext.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                dbContext.Entry(model).Property(x => x.Title).IsModified = true;
                dbContext.Entry(model).Property(x => x.Description).IsModified = true;
                dbContext.Entry(model).Property(x => x.Link).IsModified = true;
                dbContext.Entry(model).Property(x => x.Alias).IsModified = true;
                dbContext.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                dbContext.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                dbContext.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                dbContext.Entry(model).Property(x => x.Position).IsModified = true;
                dbContext.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                dbContext.Entry(model).Property(x => x.Modifiedby).IsModified = true;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbContext.Categories.Find(id);
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                dbContext.Categories.Remove(item);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}