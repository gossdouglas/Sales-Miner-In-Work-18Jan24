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
            string sqlquery = "SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID," +

                "cmps411.tbl_eqpmt_kits_current.machineID, cmps411.tbl_eqpmt_kits_current.kitID," +

                "cmps411.tbl_eqpmt_kits_avlbl.model, cmps411.tbl_eqpmt_kits_avlbl.kitID " +

                "FROM cmps411.tbl_customer_eqpmt " +

                "LEFT JOIN cmps411.tbl_eqpmt_kits_current ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID " +
                "LEFT JOIN cmps411.tbl_eqpmt_kits_avlbl ON cmps411.tbl_customer_eqpmt.model = tbl_eqpmt_kits_avlbl.model " +

                "WHERE cmps411.tbl_eqpmt_kits_current.machineID is null AND cmps411.tbl_eqpmt_kits_current.kitID is null";

            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                machinesW_kitsAvlbl_BnotInstalled mWkitsAvlblBnotInstalled = new machinesW_kitsAvlbl_BnotInstalled();

                mWkitsAvlblBnotInstalled.customerCode = dr[0].ToString();
                mWkitsAvlblBnotInstalled.eqpmtType = dr[1].ToString();
                mWkitsAvlblBnotInstalled.model = dr[2].ToString();
                mWkitsAvlblBnotInstalled.machineID = dr[3].ToString();
                mWkitsAvlblBnotInstalled.kitsCurrent_machineID = dr[4].ToString();
                mWkitsAvlblBnotInstalled.kitsCurrent_kitID = dr[5].ToString();
                mWkitsAvlblBnotInstalled.kitsAvlbl_model = dr[6].ToString();
                mWkitsAvlblBnotInstalled.kitsAvlbl_kitID = dr[7].ToString();

                mWkaBni.Add(mWkitsAvlblBnotInstalled);
            }
            return View(mWkaBni);
        }
    }
}