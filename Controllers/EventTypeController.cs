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

        // GET: KitMgmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_event_type> eventTypeMgmt = entities.tbl_event_type.ToList();

            return View(eventTypeMgmt.ToList());
        }

        // GET: KitsAvlblMgmt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_event_type tbl_event_type = db.tbl_event_type.Find(id);
            if (tbl_event_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_event_type);
        }

        // GET: KitsAvlblMgmt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitsAvlblMgmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventID,eventType,id")] tbl_event_type tbl_event_type)
        {
            if (ModelState.IsValid)
            {
                db.tbl_event_type.Add(tbl_event_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_event_type);
        }

        // GET: KitsAvlblMgmt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_event_type tbl_event_type = db.tbl_event_type.Find(id);
            if (tbl_event_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_event_type);
        }

        // POST: KitsAvlblMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventID,eventType,id")] tbl_event_type tbl_event_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_event_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_event_type);
        }

        // GET: KitsAvlblMgmt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_event_type tbl_event_type = db.tbl_event_type.Find(id);
            if (tbl_event_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_event_type);
        }

        // POST: KitsAvlblMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_event_type tbl_event_type = db.tbl_event_type.Find(id);
            db.tbl_event_type.Remove(tbl_event_type);
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
