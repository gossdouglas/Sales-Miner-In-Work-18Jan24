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
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

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

                //begin add KitList

                //List<string> testKitList = new List<string>();
                //testKitList.Add("aa");
                //testKitList.Add("bb");
                //testKitList.Add("cc");
                //testKitList.Add("dd");
                vm_SalesCustomer1.kitsCurrent = test();

                //end add KitList

                SalesCustomer1.Add(vm_SalesCustomer1);
            }
            sqlconn.Close();
            //end query for .....
          
            return View(SalesCustomer1);
        }
        private List<string> test ()
        {
            List<string> testKitList = new List<string>();
            testKitList.Add("aa");
            testKitList.Add("bb");
            testKitList.Add("cc");           
            return testKitList; 
        }

    }

}