using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ACustomersController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: ACustomers
        public ActionResult Index()
        {
            return View(db.ACustomers.ToList());
        }

        // GET: ACustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACustomer aCustomer = db.ACustomers.Find(id);
            if (aCustomer == null)
            {
                return HttpNotFound();
            }
            return View(aCustomer);
        }

        // GET: ACustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cus_Id,fname,lname,gender,email,tel,address,cdate")] ACustomer aCustomer)
        {
            if (ModelState.IsValid)
            {
                db.ACustomers.Add(aCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCustomer);
        }
        public ActionResult Login()
        {
            return View();
        }



        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "email")] ACustomer anshuja1)
        {
            ACustomer anshuja = db.ACustomers.FirstOrDefault(u1 => u1.email == anshuja1.email );
            if (anshuja != null)
            {
                return View("WelcomeCustomer");
            }

            return View();
        }
        // GET: ACustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACustomer aCustomer = db.ACustomers.Find(id);
            if (aCustomer == null)
            {
                return HttpNotFound();
            }
            return View(aCustomer);
        }

        // POST: ACustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cus_Id,fname,lname,gender,email,tel,address,cdate")] ACustomer aCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCustomer);
        }

        // GET: ACustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACustomer aCustomer = db.ACustomers.Find(id);
            if (aCustomer == null)
            {
                return HttpNotFound();
            }
            return View(aCustomer);
        }

        // POST: ACustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACustomer aCustomer = db.ACustomers.Find(id);
            db.ACustomers.Remove(aCustomer);
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

        public ActionResult LongTermCustomers()
        {
            DateTime fiveYearsAgo = DateTime.Today.AddYears(-5);



            var longTermCustomers = db.ACustomers
                .Where(customer => customer.cdate <= fiveYearsAgo)
                .ToList();



            return View(longTermCustomers);
        }
    }
}
