using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class CustomerEventController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerEvent
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_customer_event> custEvent = entities.tbl_customer_event.ToList();

            //ViewBag.eventType = new SelectList(db.tbl_event_type, "eventType", "eventType");
            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "customerCode");
            //ViewBag.customerName = new SelectList(db.tbl_customer, "name", "name");

            return View(custEvent.ToList());
            //return View(db.tbl_customer.ToList());
        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddEvent(tbl_customer_event eventAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_customer_event.Add(new tbl_customer_event()
                {
                    customerCode = eventAdd.customerCode,
                    eventID = eventAdd.eventID,
                    eventType = eventAdd.eventType,
                    startDate = eventAdd.startDate,
                    endDate = eventAdd.endDate
                });


                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteEvent(tbl_customer_event eventDelete)
        {
            tbl_customer_event tbl_customer_event = db.tbl_customer_event.Find(eventDelete.id);
            db.tbl_customer_event.Remove(tbl_customer_event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //end CMPS 411 controller code

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
       // GET: CustomerMgmt/Details/5
       public ActionResult Details(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           tbl_customer tbl_customer = db.tbl_customer.Find(id);
           if (tbl_customer == null)
           {
               return HttpNotFound();
           }
           return View(tbl_customer);
       }

       // GET: CustomerMgmt/Create
       public ActionResult Create()
       {
           return View();
       }

       // POST: CustomerMgmt/Create
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for
       // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "customerCode,name,address,city,state,zipCode,id")] tbl_customer tbl_customer)
       {
           if (ModelState.IsValid)
           {
               db.tbl_customer.Add(tbl_customer);
               db.SaveChanges();
               return RedirectToAction("Index");
           }

           return View(tbl_customer);
       }

       // GET: CustomerMgmt/Edit/5
       public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           tbl_customer tbl_customer = db.tbl_customer.Find(id);
           if (tbl_customer == null)
           {
               return HttpNotFound();
           }
           return View(tbl_customer);
       }

       // POST: CustomerMgmt/Edit/5
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for
       // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "customerCode,name,address,city,state,zipCode,id")] tbl_customer tbl_customer)
       {
           if (ModelState.IsValid)
           {
               db.Entry(tbl_customer).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           return View(tbl_customer);
       }

       // GET: CustomerMgmt/Delete/5
       public ActionResult Delete(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           tbl_customer tbl_customer = db.tbl_customer.Find(id);
           if (tbl_customer == null)
           {
               return HttpNotFound();
           }
           return View(tbl_customer);
       }

       // POST: CustomerMgmt/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]

       public ActionResult DeleteConfirmed(int id)
       {
           tbl_customer tbl_customer = db.tbl_customer.Find(id);
           db.tbl_customer.Remove(tbl_customer);
           db.SaveChanges();
           return RedirectToAction("Index");
       }*/
    }
}
