using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using allpax_sale_miner.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using allpax_sale_miner.Models;
using System.Dynamic;

namespace allpax_sale_miner.Controllers
{
    public class SalesCustomerController : Controller
    {
        public allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: machinesW_kitsAvlbl
        public ActionResult Index()
        {
            List<vm_SalesCustomer> SalesCustomer1 = new List<vm_SalesCustomer>();

            string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            //begin query for .....        
            string sqlquery =
                "SELECT cmps411.tbl_customer_eqpmt.jobNum, cmps411.tbl_customer_eqpmt.customerCode, " +
                "cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID " +
                "FROM " +
                "cmps411.tbl_customer_eqpmt";
            //end query for .....
           
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                vm_SalesCustomer vm_SalesCustomer1 = new vm_SalesCustomer();

                vm_SalesCustomer1.jobNo = dr[0].ToString();
                vm_SalesCustomer1.customerCode = dr[1].ToString();
                vm_SalesCustomer1.model = dr[2].ToString();
                vm_SalesCustomer1.machineID = dr[3].ToString();

                //begin add kitsCurrent;
                //vm_SalesCustomer1.kitsCurrent = kitsCurrent();
                //end add kitsCurrent
                //test
                var sql = db.tbl_customer_eqpmt.SqlQuery
                    ("SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, " +
                    "cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID, cmps411.tbl_eqpmt_kits_current.machineID, " +
                    "cmps411.tbl_eqpmt_kits_current.kitID " +
                    "FROM cmps411.tbl_customer_eqpmt " +
                    "INNER JOIN cmps411.tbl_eqpmt_kits_current ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID; ").ToList();
                //test
                SalesCustomer1.Add(vm_SalesCustomer1);
            }
            sqlconn.Close();
            
          
            return View(SalesCustomer1);
        }
        private List<string> kitsCurrent()
        {
            List<string> kc = new List<string>();
            kc.Add("aa");
            kc.Add("bb");
            kc.Add("cc");           
            return kc;            
        }

    }

}