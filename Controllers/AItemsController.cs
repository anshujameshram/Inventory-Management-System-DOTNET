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
    public class AItemsController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: AItems
        public ActionResult Index()
        {
            var aItems = db.AItems.Include(a => a.ACategory).Include(a => a.Anshuja);
            return View(aItems.ToList());
        }

        // GET: AItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AItem aItem = db.AItems.Find(id);
            if (aItem == null)
            {
                return HttpNotFound();
            }
            return View(aItem);
        }

        // GET: AItems/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.ACategories, "cat_id", "cat_name");
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname");
            return View();
        }

        // POST: AItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_item,itname,cat_id,qty,sold_qty,cost,manufacturer,address,telephone,sales_price,user_id")] AItem aItem)
        {
            if (ModelState.IsValid)
            {
                db.AItems.Add(aItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.ACategories, "cat_id", "cat_name", aItem.cat_id);
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname", aItem.user_id);
            return View(aItem);
        }

        // GET: AItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AItem aItem = db.AItems.Find(id);
            if (aItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.ACategories, "cat_id", "cat_name", aItem.cat_id);
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname", aItem.user_id);
            return View(aItem);
        }

        // POST: AItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_item,itname,cat_id,qty,sold_qty,cost,manufacturer,address,telephone,sales_price,user_id")] AItem aItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.ACategories, "cat_id", "cat_name", aItem.cat_id);
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname", aItem.user_id);
            return View(aItem);
        }

        // GET: AItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AItem aItem = db.AItems.Find(id);
            if (aItem == null)
            {
                return HttpNotFound();
            }
            return View(aItem);
        }

        // POST: AItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AItem aItem = db.AItems.Find(id);
            db.AItems.Remove(aItem);
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
        public ActionResult Report()
        {
            var aItems = db.AItems.Include(a => a.ACategory).Include(a => a.Anshuja);
            return View(aItems.ToList());
        }
    }
}
