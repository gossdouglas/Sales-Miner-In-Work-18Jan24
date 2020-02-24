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
    public class EquipmentMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: EquipmentMgmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_eqpmt_type> eqpmntMgmt = entities.tbl_eqpmt_type.ToList();

            return View(eqpmntMgmt.ToList());
            //return View(db.tbl_eqpmt_type.ToList());
        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddEquipment(tbl_eqpmt_type equipmentAdd)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                entities.tbl_customer.Add(new tbl_customer
                {
                    eqpmtType = equipmentAdd.eqpmtType,
                    model = equipmentAdd.model,
                    description = equipmentAdd.description,
                });

                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        public ActionResult DeleteEquipment(tbl_eqpmt_type eqpmtDelete)
        {
            tbl_customer tbl_eqpmt_type = db.tbl_eqpmt_type.Find(eqpmtDelete.id);
            db.tbl_eqpmt_type.Remove(tbl_eqpmt_type);
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