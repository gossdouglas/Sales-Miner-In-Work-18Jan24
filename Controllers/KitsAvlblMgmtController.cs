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
    public class KitsAvlblMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: KitsAvlblMgmt
        public ActionResult Index()
        {
            return View(db.tbl_eqpmt_kits_avlbl.ToList());
        }

        // GET: KitsAvlblMgmt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_kits_avlbl tbl_eqpmt_kits_avlbl = db.tbl_eqpmt_kits_avlbl.Find(id);
            if (tbl_eqpmt_kits_avlbl == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_kits_avlbl);
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
        public ActionResult Create([Bind(Include = "eqpmtType,kitID,id")] tbl_eqpmt_kits_avlbl tbl_eqpmt_kits_avlbl)
        {
            if (ModelState.IsValid)
            {
                db.tbl_eqpmt_kits_avlbl.Add(tbl_eqpmt_kits_avlbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_eqpmt_kits_avlbl);
        }

        // GET: KitsAvlblMgmt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_kits_avlbl tbl_eqpmt_kits_avlbl = db.tbl_eqpmt_kits_avlbl.Find(id);
            if (tbl_eqpmt_kits_avlbl == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_kits_avlbl);
        }

        // POST: KitsAvlblMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eqpmtType,kitID,id")] tbl_eqpmt_kits_avlbl tbl_eqpmt_kits_avlbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_eqpmt_kits_avlbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_eqpmt_kits_avlbl);
        }

        // GET: KitsAvlblMgmt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_eqpmt_kits_avlbl tbl_eqpmt_kits_avlbl = db.tbl_eqpmt_kits_avlbl.Find(id);
            if (tbl_eqpmt_kits_avlbl == null)
            {
                return HttpNotFound();
            }
            return View(tbl_eqpmt_kits_avlbl);
        }

        // POST: KitsAvlblMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_eqpmt_kits_avlbl tbl_eqpmt_kits_avlbl = db.tbl_eqpmt_kits_avlbl.Find(id);
            db.tbl_eqpmt_kits_avlbl.Remove(tbl_eqpmt_kits_avlbl);
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
