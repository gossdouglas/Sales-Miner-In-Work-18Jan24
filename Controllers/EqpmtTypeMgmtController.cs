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
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_eqpmt_type_mgmt> eqpmtTypeMgmt = entities.tbl_eqpmt_type_mgmt.ToList();

            return View(eqpmtTypeMgmt.ToList());
        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddEqpmtType(tbl_eqpmt_type_mgmt eqpmtTypeAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_eqpmt_type_mgmt.Add(new tbl_eqpmt_type_mgmt
                {
                    eqpmtType = eqpmtTypeAdd.eqpmtType
                });


                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteEqpmtType(tbl_eqpmt_type_mgmt eqpmtTypeDelete)
        {
            tbl_eqpmt_type_mgmt tbl_eqpmt_type_mgmt = db.tbl_eqpmt_type_mgmt.Find(eqpmtTypeDelete.id);
            db.tbl_eqpmt_type_mgmt.Remove(tbl_eqpmt_type_mgmt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEqpmtType(tbl_eqpmt_type_mgmt eqpmtTypeUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_eqpmt_type_mgmt UpdatedEqpmtType = (from c in entities.tbl_eqpmt_type_mgmt
                                                where c.id == eqpmtTypeUpdate.id
                                                select c).FirstOrDefault();
                UpdatedEqpmtType.eqpmtType = eqpmtTypeUpdate.eqpmtType;

                entities.SaveChanges();
            }

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
