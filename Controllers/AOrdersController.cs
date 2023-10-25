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
    public class AOrdersController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: AOrders
        public ActionResult Index()
        {
            var aOrders = db.AOrders.Include(a => a.ACustomer).Include(a => a.Anshuja);
            return View(aOrders.ToList());
        }

        // GET: AOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AOrder aOrder = db.AOrders.Find(id);
            if (aOrder == null)
            {
                return HttpNotFound();
            }
            return View(aOrder);
        }

        // GET: AOrders/Create
        public ActionResult Create()
        {
            
            ViewBag.cust_id = new SelectList(db.ACustomers, "cus_Id", "cus_Id");
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname");
            ViewBag.item_id = new SelectList(db.AItems, "id", "id_item");
            return View();
        }

        // POST: AOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ordname,qty,orddate,duedate,cust_id,status,user_id,item_id")] AOrder aOrder)
        {

            if (ModelState.IsValid)
            {
                // Retrieve the selected item
                var selectedItem = db.AItems.Find(aOrder.item_id);



                if (selectedItem != null)
                {
                    // Calculate the available quantity
                    int availableQty = (int)selectedItem.qty - (int)selectedItem.sold_qty;



                    // Check if the order quantity is less than or equal to the available quantity
                    if (aOrder.qty <= availableQty)
                    {
                        // Increase the sales_qty for the selected item
                        selectedItem.sold_qty += aOrder.qty;
                        db.Entry(selectedItem).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        // Add the order to the database
                        db.AOrders.Add(aOrder);
                        db.SaveChanges();
                        return RedirectToAction("Index");



                    }
                    else
                    {
                        ModelState.AddModelError("qty", $"Order quantity exceeds available quantity ({availableQty} available).");
                    }
                }
                else
                {
                    ModelState.AddModelError("items_id", "Item not found.");
                }
            }
            if (aOrder.orddate < DateTime.Today.Date)
            {
                ModelState.AddModelError("orddate", "Order date cannot be in the past.");
            }



            if (aOrder.duedate < aOrder.orddate)
            {
                ModelState.AddModelError("duedate", "Due date must be on or after the order date.");
            }

            var customers = db.ACustomers.ToList();

            ViewBag.CustomerList = new SelectList(customers, "cus_Id", "cus_Id");
            //ViewBag.cus_id = new SelectList(db.ACustomers, "cus_Id", "cus_Id");
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname", aOrder.user_id);
            ViewBag.item_id = new SelectList(db.AItems, "id", "id_item",aOrder.item_id);


            // Retrieve the qty data from the items table
            var itemQtyList = db.AItems.Select(item => new SelectListItem
            {
                Value = item.id.ToString(),
                Text = item.id.ToString()
            }).ToList();



            ViewBag.ItemQtyList = itemQtyList;



            return View(aOrder);
        }

        // GET: AOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AOrder aOrder = db.AOrders.Find(id);
            if (aOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.cust_id = new SelectList(db.ACustomers, "cus_Id", "fname", aOrder.cust_id);
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname", aOrder.user_id);
            return View(aOrder);
        }

        // POST: AOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ordname,qty,orddate,duedate,cust_id,status,user_id")] AOrder aOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cust_id = new SelectList(db.ACustomers, "cus_Id", "fname", aOrder.cust_id);
            ViewBag.user_id = new SelectList(db.Anshujas, "Id", "fname", aOrder.user_id);
            return View(aOrder);
        }

        // GET: AOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AOrder aOrder = db.AOrders.Find(id);
            if (aOrder == null)
            {
                return HttpNotFound();
            }
            return View(aOrder);
        }

        // POST: AOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AOrder aOrder = db.AOrders.Find(id);
            db.AOrders.Remove(aOrder);
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
