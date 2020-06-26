using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using allpax_sale_miner.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace allpax_sale_miner.Controllers
{
    public class machinesW_kitsAvlbl_BnotInstalledController : Controller
    {
        // GET: machinesW_kitsAvlbl
        public ActionResult Index()
        {
            List<machinesW_kitsAvlbl_BnotInstalled> mWkaBni = new List<machinesW_kitsAvlbl_BnotInstalled>();
            string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            // begin empty and build custEqpmtWkitsAvlbl 

            /*
            string custEqpmtWkitsAvlbl =
                @"DELETE FROM cmps411.custEqpmtWkitsAvlbl " +

                "INSERT INTO cmps411.custEqpmtWkitsAvlbl" +

                "(customerCode_cEqpmt, eqpmtType_cEqpmt, model_cEqpmt, machineID_cEqpmt, jobNum_cEqpmt, eqpmtType_kitsAvlbl, model_kitsAvlbl, kitID_kitsAvlbl) " +

                "SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, cmps411.tbl_customer_eqpmt.model, " +
                "cmps411.tbl_customer_eqpmt.machineID, cmps411.tbl_customer_eqpmt.jobNum, cmps411.tbl_eqpmt_kits_avlbl.model, " +
                "cmps411.tbl_eqpmt_kits_avlbl.model, cmps411.tbl_eqpmt_kits_avlbl.kitID"+ 

                "FROM cmps411.tbl_customer_eqpmt " +
                "INNER JOIN cmps411.tbl_eqpmt_kits_avlbl " +
                "ON cmps411.tbl_customer_eqpmt.model = tbl_eqpmt_kits_avlbl.model " +
                "ORDER BY cmps411.tbl_customer_eqpmt.customerCode";

            SqlCommand sqlcomm1 = new SqlCommand();
            sqlcomm1.Connection.Open();
            sqlcomm1.CommandText = custEqpmtWkitsAvlbl;
            sqlcomm1.ExecuteNonQuery();
            sqlcomm1.Connection = sqlconn;
            sqlcomm1.ExecuteNonQuery();

            //sqlcomm1.Connection.Close();
            // end empty and build custEqpmtWkitsAvlbl
            */

            //begin empty and build custEqpmtWkitsInstld

            /*
            string custEqpmtWkitsInstld =
                "DELETE FROM cmps411.custEqpmtWkitsInstld"+

                "INSERT INTO cmps411.custEqpmtWkitsInstld"+
                "(customerCode_cEqpmt, eqpmtType_cEqpmt, model_cEqpmt, machineID_cEqpmt, jobNum_cEqpmt,"+

                "machineID_kitsCurrent, kitID_kitsCurrent)"+

                "SELECT"+
                "cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, cmps411.tbl_customer_eqpmt.model, " +
                "cmps411.tbl_customer_eqpmt.machineID, cmps411.tbl_customer_eqpmt.jobNum, cmps411.tbl_eqpmt_kits_current.machineID, cmps411.tbl_eqpmt_kits_current.kitID"+

                "FROM cmps411.tbl_customer_eqpmt"+
                "INNER JOIN cmps411.tbl_eqpmt_kits_current ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID"+

                "ORDER BY"+
                "cmps411.tbl_customer_eqpmt.customerCode";

            SqlCommand sqlcomm2 = new SqlCommand(custEqpmtWkitsInstld, sqlconn);
            sqlcomm2.Connection.Open();
            sqlcomm2.ExecuteNonQuery();
            //end empty and build custEqpmtWkitsInstld

            */
    

            //begin query for kits available, but not installed
            string sqlquery = 
                "SELECT custEqpmtWkitsAvlbl.customerCode_cEqpmt, custEqpmtWkitsAvlbl.jobNum_cEqpmt, custEqpmtWkitsAvlbl.eqpmtType_cEqpmt, " +
                "cmps411.custEqpmtWkitsAvlbl.model_cEqpmt, cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt, kitID_kitsAvlbl " +

                "FROM cmps411.custEqpmtWkitsAvlbl " +
                "LEFT JOIN cmps411.custEqpmtWkitsInstld ON " +
                "cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt = cmps411.custEqpmtWkitsInstld.machineID_kitsCurrent " +
                "AND cmps411.custEqpmtWkitsAvlbl.kitID_kitsAvlbl = cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent " +
                "WHERE custEqpmtWkitsInstld.machineID_kitsCurrent is NULL AND cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent is NULL";

            SqlCommand sqlcomm3 = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm3);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                machinesW_kitsAvlbl_BnotInstalled mWkitsAvlblBnotInstalled = new machinesW_kitsAvlbl_BnotInstalled();

                mWkitsAvlblBnotInstalled.customerCode = dr[0].ToString();
                mWkitsAvlblBnotInstalled.jobNo = dr[1].ToString();               
                mWkitsAvlblBnotInstalled.eqpmtType = dr[2].ToString();
                mWkitsAvlblBnotInstalled.model = dr[3].ToString();
                mWkitsAvlblBnotInstalled.machineID = dr[4].ToString();
                mWkitsAvlblBnotInstalled.kitsAvlbl_kitID = dr[5].ToString();

                 mWkaBni.Add(mWkitsAvlblBnotInstalled);
            }
            //end query for kits available, but not installed
            return View(mWkaBni);
        }
    }
}