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
    public class EventTypeController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_event_type> eventType = entities.tbl_event_type.ToList();

            return View(eventType.ToList());
        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddEvent(tbl_event_type eventAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_event_type.Add(new tbl_event_type()
                {
                    eventID = eventAdd.eventID,
                    eventType = eventAdd.eventType
                   
                });
                entities.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEvent(tbl_event_type eventDelete)
        {
            tbl_event_type tbl_event_type = db.tbl_event_type.Find(eventDelete.id);
            db.tbl_event_type.Remove(tbl_event_type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEvent(tbl_event_type eventUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_event_type updatedEvent = (from c in entities.tbl_event_type
                                                   where c.id == eventUpdate.id
                                                   select c).FirstOrDefault();
                updatedEvent.eventID = eventUpdate.eventID;
                updatedEvent.eventType = eventUpdate.eventType;
               
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
