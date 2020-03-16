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
