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
using System.Security.Cryptography;

namespace allpax_sale_miner.Controllers
{
    public class SalesCustomerController : Controller
    {

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
                vm_SalesCustomer1.kitsCurrent = kitsCurrent(vm_SalesCustomer1.customerCode, vm_SalesCustomer1.machineID);
                vm_SalesCustomer1.kitsAvlblbNotInstld = kitsAvlblbNotInstld();
                SalesCustomer1.Add(vm_SalesCustomer1);
            }
            sqlconn.Close();
                      
            return View(SalesCustomer1);
        }
        //begin add kitsCurrent
        public List<string> kitsCurrent(string customerCode, string machineID)
        {
            List<string> kc = new List<string>();

            string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            //begin query for currently installed kits by machine 
            string sqlquery2 = "SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_eqpmt_kits_current.machineID, cmps411.tbl_eqpmt_kits_current.kitID " +
                "FROM cmps411.tbl_customer_eqpmt " +
                "INNER JOIN cmps411.tbl_eqpmt_kits_current ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID " +
                "WHERE cmps411.tbl_customer_eqpmt.customerCode = @customerCode AND cmps411.tbl_eqpmt_kits_current.machineID = @machineID";
            //end query for currently installed kits by machine 

            SqlCommand sqlcomm2 = new SqlCommand(sqlquery2, sqlconn);
            sqlcomm2.Parameters.Add(new SqlParameter("customerCode", customerCode));
            sqlcomm2.Parameters.Add(new SqlParameter("machineID", machineID));
            SqlDataAdapter sda2 = new SqlDataAdapter(sqlcomm2);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                kc.Add(dr2[2].ToString());              
            }
            return kc;            
        }
        public List<string> kitsAvlblbNotInstld()
        {
            List<string> mWkaBni = new List<string>();

            string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            //begin query for kits available but not installed by machine
            string sqlquery3 = "SELECT custEqpmtWkitsAvlbl.customerCode_cEqpmt, custEqpmtWkitsAvlbl.jobNum_cEqpmt, custEqpmtWkitsAvlbl.eqpmtType_cEqpmt, " +
                "cmps411.custEqpmtWkitsAvlbl.model_cEqpmt, cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt, kitID_kitsAvlbl " +
                "FROM cmps411.custEqpmtWkitsAvlbl " +
                "LEFT JOIN cmps411.custEqpmtWkitsInstld " +
                "ON cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt = cmps411.custEqpmtWkitsInstld.machineID_kitsCurrent " +
                "AND cmps411.custEqpmtWkitsAvlbl.kitID_kitsAvlbl = cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent " +
                "WHERE custEqpmtWkitsInstld.machineID_kitsCurrent is NULL " +
                "AND cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent is NULL " +
                "AND custEqpmtWkitsAvlbl.customerCode_cEqpmt = 'AHV' " +
                "AND custEqpmtWkitsAvlbl.jobNum_cEqpmt = 'J2001' " +
                "AND cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt = 'AHV-LDR-01'";
            //end query for kits available but not installed by machine

            SqlCommand sqlcomm3 = new SqlCommand(sqlquery3, sqlconn);
            //sqlcomm3.Parameters.Add(new SqlParameter("customerCode", customerCode));
            //sqlcomm3.Parameters.Add(new SqlParameter("jobNo", jobNo));
            //sqlcomm3.Parameters.Add(new SqlParameter("machineID", machineID));
            SqlDataAdapter sda3 = new SqlDataAdapter(sqlcomm3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            foreach (DataRow dr3 in dt3.Rows)
            {
                mWkaBni.Add(dr3[5].ToString());
            }
            return mWkaBni;
        }

    }


}