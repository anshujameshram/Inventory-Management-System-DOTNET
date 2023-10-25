using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ACategoriesController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: ACategories
        public ActionResult Index()
        {
            return View(db.ACategories.ToList());
        }

        // GET: ACategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACategory aCategory = db.ACategories.Find(id);
            if (aCategory == null)
            {
                return HttpNotFound();
            }
            return View(aCategory);
        }

        // GET: ACategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_name,cat_comment,cat_date")] ACategory aCategory)
        {
            if (ModelState.IsValid)
            {
                db.ACategories.Add(aCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCategory);
        }

        // GET: ACategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACategory aCategory = db.ACategories.Find(id);
            if (aCategory == null)
            {
                return HttpNotFound();
            }
            return View(aCategory);
        }

        // POST: ACategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name,cat_comment,cat_date")] ACategory aCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCategory);
        }

        // GET: ACategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACategory aCategory = db.ACategories.Find(id);
            if (aCategory == null)
            {
                return HttpNotFound();
            }
            return View(aCategory);
        }

        // POST: ACategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACategory aCategory = db.ACategories.Find(id);
            db.ACategories.Remove(aCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
