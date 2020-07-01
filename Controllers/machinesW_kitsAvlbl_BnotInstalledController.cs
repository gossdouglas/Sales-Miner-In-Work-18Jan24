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

namespace allpax_sale_miner.Controllers
{
    public class machinesW_kitsAvlbl_BnotInstalledController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: machinesW_kitsAvlbl
        public ActionResult Index()
        {
            List<machinesW_kitsAvlbl_BnotInstalled> mWkaBni = new List<machinesW_kitsAvlbl_BnotInstalled>();
            string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            // begin empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables  
            //this is handled by a stored procedure on the sql server named dbo.bldSalesOppsTables
            sqlconn.Open();
            SqlCommand sqlcomm1 = new SqlCommand("dbo.bldSalesOppsTables", sqlconn);
            sqlcomm1.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm1.ExecuteNonQuery();
            sqlconn.Close();
            //end empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables 

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