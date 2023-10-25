using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
namespace WebApplication1.Controllers
{
    public class AnshujasController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: Anshujas
        public ActionResult Index()
        {
            return View(db.Anshujas.ToList());
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

        public ActionResult Login([Bind(Include = "email, password")] Anshuja myUser)
        {
            // Check if a user with the provided email exists in the database
            Anshuja myUser1 = db.Anshujas.FirstOrDefault(u => u.email == myUser.email);



            if (myUser1 != null)
            {
                // Check if the password matches
                if (myUser1.password == myUser.password)
                {
                    if (myUser1.user_level == "admin")
                    {
                        return View("welcome");
                    }
                    else if (myUser1.user_level == "salesperson")
                    {
                        return View("salesWelcome");
                    }
                }
                else
                {
                    // Password is incorrect
                    ModelState.AddModelError("password", "Incorrect Password. Please try again.");
                }
            }
            else
            {
                // Email is incorrect
                ModelState.AddModelError("email", "Email address is not valid.");
            }
           // if (ModelState.ContainsKey("password"))
           // {
           //     ModelState["password"].Errors.Clear();
          //  }


            return View(myUser);
        }
        // GET: Anshujas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anshuja anshuja = db.Anshujas.Find(id);
            if (anshuja == null)
            {
                return HttpNotFound();
            }
            return View(anshuja);
        }

        // GET: Anshujas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anshujas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fname,lname,Attname,dob,gender,email,tel,address,user_level,password,udate")] Anshuja anshuja)
        {
            if (ModelState.IsValid)
            {
                db.Anshujas.Add(anshuja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(anshuja);
        }

        // GET: Anshujas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anshuja anshuja = db.Anshujas.Find(id);
            if (anshuja == null)
            {
                return HttpNotFound();
            }
            return View(anshuja);
        }

        // POST: Anshujas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fname,lname,Attname,dob,gender,email,tel,address,user_level,password,udate")] Anshuja anshuja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anshuja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anshuja);
        }

        // GET: Anshujas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anshuja anshuja = db.Anshujas.Find(id);
            if (anshuja == null)
            {
                return HttpNotFound();
            }
            return View(anshuja);
        }

        // POST: Anshujas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anshuja anshuja = db.Anshujas.Find(id);
            db.Anshujas.Remove(anshuja);
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
        public ActionResult Logout()
        {
            return View();
        }

    }
}
