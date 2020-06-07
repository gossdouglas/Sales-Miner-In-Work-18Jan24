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
    public class CustomerMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerMgmt
        public ActionResult Index()
        {
            //allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            //List<tbl_customer> custMgmt = entities.tbl_customer.ToList();
            

            var sql = db.tbl_customer.SqlQuery("SELECT * from cmps411.tbl_customer").ToList();

            //return View(custMgmt.ToList());
            return View(sql.ToList());
            
        }
                  
        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddCustomer(tbl_customer customerAdd)
        {
            //using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            //{
            //    entities.tbl_customer.Add(new tbl_customer
            //    {
            //        customerCode = customerAdd.customerCode,
            //        name = customerAdd.name,
            //        address = customerAdd.address,
            //        city = customerAdd.city,
            //        state = customerAdd.state,
            //        zipCode = customerAdd.zipCode,
            //    });


            //    entities.SaveChanges();
            //}
           
            db.Database.ExecuteSqlCommand("Insert into cmps411.tbl_customer Values({0},{1},{2}, {3}, {4}, {5})", customerAdd.customerCode, customerAdd.name, customerAdd.address, customerAdd.city, customerAdd.state, customerAdd.zipCode);
            return new EmptyResult();
        }

        public ActionResult DeleteCustomer(tbl_customer custDelete)
        {
            tbl_customer tbl_customer = db.tbl_customer.Find(custDelete.id);
            db.tbl_customer.Remove(tbl_customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCustomer(tbl_customer custUpdate)
        {
            using (allpax_sale_minerEntities entities = new allpax_sale_minerEntities())
            {
                tbl_customer updatedCustomer = (from c in entities.tbl_customer
                                                           where c.id == custUpdate.id
                                                           select c).FirstOrDefault();
                updatedCustomer.customerCode = custUpdate.customerCode;
                updatedCustomer.name = custUpdate.name;
                updatedCustomer.address = custUpdate.address;
                updatedCustomer.city = custUpdate.city;
                updatedCustomer.state = custUpdate.state;
                updatedCustomer.zipCode = custUpdate.zipCode;

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
