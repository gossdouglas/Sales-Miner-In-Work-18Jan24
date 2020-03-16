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

            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "customerCode");

            return View(custEvent.ToList());
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
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEvent(tbl_customer_event eventDelete)
        {
            tbl_customer_event tbl_customer_event = db.tbl_customer_event.Find(eventDelete.id);
            db.tbl_customer_event.Remove(tbl_customer_event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEvent(tbl_customer_event eventUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_customer_event updatedEvent = (from c in entities.tbl_customer_event
                                                     where c.id == eventUpdate.id
                                                     select c).FirstOrDefault();
                updatedEvent.customerCode = eventUpdate.customerCode;
                updatedEvent.eventID = eventUpdate.eventID;
                updatedEvent.eventType = eventUpdate.eventType;
                updatedEvent.startDate = eventUpdate.startDate;
                updatedEvent.endDate = eventUpdate.endDate;

                entities.SaveChanges();
            }

            return new EmptyResult();
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
    }
}
