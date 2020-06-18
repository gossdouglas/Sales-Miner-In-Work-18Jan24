using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web; 
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class SalesOppsController : Controller
    {
     
        // GET: CustomerMgmt
        public ActionResult Index()
        {
              allpax_sale_minerEntities db = new allpax_sale_minerEntities();

            // begin https://www.youtube.com/watch?v=EXimdPaGkDw this works
            List<tbl_customer_eqpmt> custEqpmt = db.tbl_customer_eqpmt.ToList();
            List<tbl_eqpmt_kits_current> kitsCurrent = db.tbl_eqpmt_kits_current.ToList();
            List<tbl_eqpmt_kits_avlbl> kitsAvlbl = db.tbl_eqpmt_kits_avlbl.ToList();         

            //var multipleTable = from ce in custEqpmt
            //                    join kc in kitsCurrent on ce.machineID equals kc.machineID
            //                    select new salesOppsModel { tbl_customer_eqpmt = ce, tbl_eqpmt_kits_current = kc };
            //return View(multipleTable);
            //end https://www.youtube.com/watch?v=EXimdPaGkDw this works

            //string query = "SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, " +
            //        "cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID, cmps411.tbl_eqpmt_kits_current.machineID, " +
            //        "cmps411.tbl_eqpmt_kits_current.kitID, cmps411.tbl_eqpmt_kits_avlbl.model, cmps411.tbl_eqpmt_kits_avlbl.kitID " +
            //        "FROM cmps411.tbl_customer_eqpmt " +
            //        "LEFT JOIN cmps411.tbl_eqpmt_kits_current ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID " +
            //        "LEFT JOIN cmps411.tbl_eqpmt_kits_avlbl ON cmps411.tbl_customer_eqpmt.model = tbl_eqpmt_kits_avlbl.model " +
            //        "WHERE cmps411.tbl_eqpmt_kits_current.machineID is null AND cmps411.tbl_eqpmt_kits_current.kitID is null";

            
            var query = "SELECT * FROM cmps411.tbl_customer_eqpmt";           
            var data = db.Database.SqlQuery<salesOppsModel>(query).ToList();
 
            return View(data);
            //return View(multipleTable);
            //return View(tables);

        }


    }
}
