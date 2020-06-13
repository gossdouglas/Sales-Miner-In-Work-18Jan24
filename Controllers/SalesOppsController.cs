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
    public class SalesOppsController : Controller
    {
     
        // GET: CustomerMgmt
        public ActionResult Index(salesOppsModel som)
        {
              allpax_sale_minerEntities db = new allpax_sale_minerEntities();
        //List<tbl_customer_eqpmt> custEqpmt = db.tbl_customer_eqpmt.ToList();
        //List<tbl_eqpmt_kits_current> kitsCurrent = db.tbl_eqpmt_kits_current.ToList();
        //List<tbl_eqpmt_kits_avlbl> kitsAvlbl = db.tbl_eqpmt_kits_avlbl.ToList();

        string query = "SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, " +
                "cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID, cmps411.tbl_eqpmt_kits_current.machineID, " +
                "cmps411.tbl_eqpmt_kits_current.kitID, cmps411.tbl_eqpmt_kits_avlbl.model, cmps411.tbl_eqpmt_kits_avlbl.kitID " +
                "FROM cmps411.tbl_customer_eqpmt " +
                "LEFT JOIN cmps411.tbl_eqpmt_kits_current ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID " +
                "LEFT JOIN cmps411.tbl_eqpmt_kits_avlbl ON cmps411.tbl_customer_eqpmt.model = tbl_eqpmt_kits_avlbl.model " +
                "WHERE cmps411.tbl_eqpmt_kits_current.machineID is null AND cmps411.tbl_eqpmt_kits_current.kitID is null";

        var data = db.Database.SqlQuery<salesOppsModel>(query).ToList();


            return View(data);
            
        }
                                
      
    }
}
