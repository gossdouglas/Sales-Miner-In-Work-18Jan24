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
    public class KitMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: KitMgmt
        public ActionResult Index()
        {
            return View(db.tbl_kit.ToList());
        }

        // GET: KitMgmt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_kit tbl_kit = db.tbl_kit.Find(id);
            if (tbl_kit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_kit);
        }

        // GET: KitMgmt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitMgmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kitID,description,filePath,id")] tbl_kit tbl_kit)
        {
            if (ModelState.IsValid)
            {
                db.tbl_kit.Add(tbl_kit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_kit);
        }

        // GET: KitMgmt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_kit tbl_kit = db.tbl_kit.Find(id);
            if (tbl_kit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_kit);
        }

        // POST: KitMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kitID,description,filePath,id")] tbl_kit tbl_kit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_kit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_kit);
        }

        // GET: KitMgmt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_kit tbl_kit = db.tbl_kit.Find(id);
            if (tbl_kit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_kit);
        }

        // POST: KitMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_kit tbl_kit = db.tbl_kit.Find(id);
            db.tbl_kit.Remove(tbl_kit);
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
