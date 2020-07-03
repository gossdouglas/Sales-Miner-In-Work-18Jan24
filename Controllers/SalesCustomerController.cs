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
            List<vm_SalesCustomer> SalesCustomer = new List<vm_SalesCustomer>();
            List<vm_SalesCustomer> SalesCustomer2 = new List<vm_SalesCustomer>();

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
                vm_SalesCustomer vm_SalesCustomer = new vm_SalesCustomer();

                vm_SalesCustomer.jobNo = dr[0].ToString();
                vm_SalesCustomer.customerCode = dr[1].ToString();
                vm_SalesCustomer.model = dr[2].ToString();
                vm_SalesCustomer.machineID = dr[3].ToString();

                SalesCustomer.Add(vm_SalesCustomer);
            }
            //end query for .....

            //begin query for .....
            string sqlquery2 =
                "SELECT cmps411.tbl_customer_eqpmt.jobNum, cmps411.tbl_customer_eqpmt.customerCode, " +
                "cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID " +
                "FROM cmps411.tbl_customer_eqpmt " +
                "WHERE cmps411.tbl_customer_eqpmt.customerCode = 'AHV'";

            SqlCommand sqlcomm2 = new SqlCommand(sqlquery2, sqlconn);
            SqlDataAdapter sda2 = new SqlDataAdapter(sqlcomm2);
            DataTable dt2 = new DataTable();
            sda.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                vm_SalesCustomer vm_SalesCustomer2 = new vm_SalesCustomer();

                vm_SalesCustomer2.jobNo = dr[0].ToString();
                vm_SalesCustomer2.customerCode = dr[1].ToString();
                vm_SalesCustomer2.model = dr[2].ToString();
                vm_SalesCustomer2.machineID = dr[3].ToString();

                SalesCustomer2.Add(vm_SalesCustomer2);
            }
            //end query for .....

            dynamic viewModel = new ExpandoObject();
            viewModel.Query1 = SalesCustomer;
            viewModel.Query2 = SalesCustomer2;
            return View(viewModel);

            //return View(SalesCustomer);
        }
    }
}