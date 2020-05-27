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
    public class CustomerEqpmtMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerEvent
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_customer_eqpmt> custEqpmt = entities.tbl_customer_eqpmt.ToList();

            //tbl_customer_eqpmt custEqpmtVM = new tbl_customer_eqpmt();
            //List<tbl_customer_eqpmt> custEqpmtVMList= custEqpmt.Select(x=>new tbl_customer_eqpmt{
            //    customerCode=x.customerCode,machineID=x.machineID, 
            //    eqpmtType=x.eqpmtType, id=x.id, jobNum=x.jobNum, )

            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "customerCode");
            ViewBag.customerName = new SelectList(db.tbl_customer, "name", "name");
            ViewBag.eqpmtType = new SelectList(db.tbl_eqpmt_type_mgmt, "eqpmtType", "eqpmtType");

            return View(custEqpmt.ToList());
        }
        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddCustEqpmt(tbl_customer_eqpmt custEqpmtAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_customer_eqpmt.Add(new tbl_customer_eqpmt()
                {
                    customerCode = custEqpmtAdd.customerCode,
                    machineID = custEqpmtAdd.machineID,
                    jobNum = custEqpmtAdd.jobNum,
                    eqpmtType = custEqpmtAdd.eqpmtType
                });
                entities.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustEqpmt(tbl_customer_eqpmt custEqpmtDelete)
        {
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(custEqpmtDelete.id);
            db.tbl_customer_eqpmt.Remove(tbl_customer_eqpmt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustEqpmt(tbl_customer_eqpmt custEqpmtUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_customer_eqpmt updatedCustEqpmt = (from c in entities.tbl_customer_eqpmt
                                                   where c.id == custEqpmtUpdate.id
                                                   select c).FirstOrDefault();
                updatedCustEqpmt.customerCode = custEqpmtUpdate.customerCode;
                updatedCustEqpmt.machineID = custEqpmtUpdate.machineID;
                updatedCustEqpmt.jobNum = custEqpmtUpdate.jobNum;
                updatedCustEqpmt.eqpmtType = custEqpmtUpdate.eqpmtType;

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
