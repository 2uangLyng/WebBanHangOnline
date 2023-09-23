using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = db.Categories;
            return View(items.ToList());
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
                model.CreactedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = db.Categories.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.ModifiedrDate = DateTime.Now;
                model.Alias = Models.Common.Filter.FilterChar(model.Title);
                db.Entry(model).Property(X => X.Title).IsModified = true;
                db.Entry(model).Property(X => X.Description).IsModified = true;
                db.Entry(model).Property(X => X.Alias).IsModified = true;
                db.Entry(model).Property(X => X.SeoDiscription).IsModified = true;
                db.Entry(model).Property(X => X.SeoKeywords).IsModified = true;
                db.Entry(model).Property(X => X.SeoTitle).IsModified = true;
                db.Entry(model).Property(X => X.Position).IsModified = true;
                db.Entry(model).Property(X => X.ModifiedrDate).IsModified = true;
                db.Entry(model).Property(X => X.ModifierBy).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Categories.Find(id);
            if(item != null)
            {
                //var Deleteitem = db.Categories.Attach(item);
                db.Categories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}