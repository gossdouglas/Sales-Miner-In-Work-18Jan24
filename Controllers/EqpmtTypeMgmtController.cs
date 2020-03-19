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
    public class EqpmtTypeMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: EqpmtTypeMgmt
        public ActionResult Index()
        {
            return View(db.tbl_eqpmt_type_mgmt.ToList());
        }

        // GET: EqpmtTypeMgmt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt = db.tbl_eqpmt_type_mgmt.Find(id);
            if (tbl_eqpmt_type_mgmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_type_mgmt);
        }

        // GET: EqpmtTypeMgmt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EqpmtTypeMgmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eqpmtType,id")] tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt)
        {
            if (ModelState.IsValid)
            {
                db.tbl_eqpmt_type_mgmt.Add(tbl_eqpmt_type_mgmt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_eqpmt_type_mgmt);
        }

        // GET: EqpmtTypeMgmt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt = db.tbl_eqpmt_type_mgmt.Find(id);
            if (tbl_eqpmt_type_mgmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_type_mgmt);
        }

        // POST: EqpmtTypeMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eqpmtType,id")] tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_eqpmt_type_mgmt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_eqpmt_type_mgmt);
        }

        // GET: EqpmtTypeMgmt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt = db.tbl_eqpmt_type_mgmt.Find(id);
            if (tbl_eqpmt_type_mgmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_type_mgmt);
        }

        // POST: EqpmtTypeMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt = db.tbl_eqpmt_type_mgmt.Find(id);
            db.tbl_eqpmt_type_mgmt.Remove(tbl_eqpmt_type_mgmt);
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
