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
    public class CurrentEqpmtKitsController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CurrentEqpmtKits
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_eqpmt_kits_current> eqpmtKitsCurrent = entities.tbl_eqpmt_kits_current.ToList();

            ViewBag.kitID = new SelectList(db.tbl_kit, "kitID", "kitID");


            return View(eqpmtKitsCurrent.ToList());
        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddCurrentEqpmt(tbl_eqpmt_kits_current currentEqpmtAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_eqpmt_kits_current.Add(new tbl_eqpmt_kits_current
                {
                    machineID = currentEqpmtAdd.machineID,
                    kitID = currentEqpmtAdd.kitID
                });


                entities.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCurrentEqpmt(tbl_eqpmt_kits_current currentEqpmtDelete)
        {
            tbl_eqpmt_kits_current tbl_eqpmt_kits_current = db.tbl_eqpmt_kits_current.Find(currentEqpmtDelete.id);
            db.tbl_eqpmt_kits_current.Remove(tbl_eqpmt_kits_current);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCurrentEqpmt(tbl_eqpmt_kits_current currentEqpmtUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_eqpmt_kits_current UpdateCurrentEqpmt = (from c in entities.tbl_eqpmt_kits_current
                                                   where c.id == currentEqpmtUpdate.id
                                                   select c).FirstOrDefault();
                UpdateCurrentEqpmt.machineID = currentEqpmtUpdate.machineID;
                UpdateCurrentEqpmt.kitID = currentEqpmtUpdate.kitID;

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
