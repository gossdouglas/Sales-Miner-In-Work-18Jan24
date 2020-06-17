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
    public class machinesW_kitsAvlblController : Controller
    {
        // GET: machinesW_kitsAvlbl
        public ActionResult Index()
        {
            List<machinesW_kitsAvlbl> mWka = new List<machinesW_kitsAvlbl>();
            string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT cmps411.tbl_customer_eqpmt.customerCode, cmps411.tbl_customer_eqpmt.eqpmtType, " +
                "cmps411.tbl_customer_eqpmt.model, cmps411.tbl_customer_eqpmt.machineID," +
                "cmps411.tbl_eqpmt_kits_current.machineID, cmps411.tbl_eqpmt_kits_current.kitID " +
                "FROM cmps411.tbl_customer_eqpmt " +
                "INNER JOIN cmps411.tbl_eqpmt_kits_current " +
                "ON cmps411.tbl_customer_eqpmt.machineID = tbl_eqpmt_kits_current.machineID";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                machinesW_kitsAvlbl mWkitsAvlbl = new machinesW_kitsAvlbl();

                mWkitsAvlbl.customerCode = dr["cmps411.tbl_customer_eqpmt.customerCode"].ToString();
                mWkitsAvlbl.eqpmtType = dr["cmps411.tbl_customer_eqpmt.eqpmtType"].ToString();
                mWkitsAvlbl.model = dr["cmps411.tbl_customer_eqpmt.model"].ToString();
                mWkitsAvlbl.machineID = dr["cmps411.tbl_customer_eqpmt.machineID"].ToString();
                mWkitsAvlbl.machineID2 = dr["tbl_eqpmt_kits_current.machineID"].ToString();
                mWkitsAvlbl.kitID = dr["tbl_eqpmt_kits_current.kitID"].ToString();

                mWka.Add(mWkitsAvlbl);
            }
            return View(mWka);
        }
    }
}