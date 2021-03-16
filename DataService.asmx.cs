using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using allpax_sale_miner.Models.Dropdown_Models;
using allpax_sale_miner.ViewModels;
using allpax_sale_miner.Models;

namespace allpax_sale_miner
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        [WebMethod]
        public void GetCustomerCodes()
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_customerCode> customerCodes = new List<dpdwn_customerCode>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetCustomerCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_customerCode customerCode = new dpdwn_customerCode();
                    customerCode.customerCode = rdr["customerCode"].ToString();
                    customerCodes.Add(customerCode);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(customerCodes));

        }
        [WebMethod]
        public void GetEqpmtTypes()
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_eqpmtType> eqpmtTypes = new List<dpdwn_eqpmtType>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEqpmtType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_eqpmtType eqpmtType = new dpdwn_eqpmtType();
                    eqpmtType.eqpmtType = rdr["eqpmtType"].ToString();
                    eqpmtTypes.Add(eqpmtType);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(eqpmtTypes));

        }
        [WebMethod]
        public void GetEqpmtModelsByEqpmtTypes(string eqpmtType)
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_model> models = new List<dpdwn_model>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEqpmtModelByEqpmtType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@eqpmtType",
                    Value = eqpmtType
                };
                cmd.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_model model = new dpdwn_model();
                    model.eqpmtType = rdr["eqpmtType"].ToString();
                    model.model = rdr["model"].ToString();
                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));

        }
        [WebMethod]
        public void GetEventTypes()
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_eventType> EventTypes = new List<dpdwn_eventType>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEventType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_eventType eventType = new dpdwn_eventType();
                    eventType.eventType = rdr["eventType"].ToString();
                    EventTypes.Add(eventType);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(EventTypes));

        }
        [WebMethod]
        public void GetStates()
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_states> States = new List<dpdwn_states>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetStates", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_states state = new dpdwn_states();
                    state.abbrev = rdr["abbrev"].ToString();
                    state.state = rdr["state"].ToString();
                    States.Add(state);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(States));

        }
        [WebMethod]
        public void GetKitsAvlblBnotInstalledByMachineID(string machineID)
        {                    
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_kitsAvlblbNotInstld> kaBnIs = new List<dpdwn_kitsAvlblbNotInstld>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                // begin empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables  
                //this is handled by a stored procedure on the sql server named dbo.bldSalesOppsTables
                con.Open();
                SqlCommand sqlcomm1 = new SqlCommand("dbo.bldSalesOppsTables", con);
                sqlcomm1.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcomm1.ExecuteNonQuery();
                //end empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables

                SqlCommand cmd = new SqlCommand("spGetKitsAvlblBnotInstalledByMachineID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@machineID",
                    Value = machineID
                };
                cmd.Parameters.Add(param);
                //con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_kitsAvlblbNotInstld kaBnI = new dpdwn_kitsAvlblbNotInstld();
                    kaBnI.machineID = rdr["machineID_cEqpmt"].ToString();
                    kaBnI.kitsAvlblbNotInstld = rdr["kitID_kitsAvlbl"].ToString();
                    //kaBnI.descKitItem_1 = rdr["descKitItem_1"].ToString();
                    //kaBnI.partNoKitItem_1 = rdr["partNoKitItem_1"].ToString();
                    kaBnIs.Add(kaBnI);
                }               
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(kaBnIs));            
        }
        [WebMethod]
        public void GetKitsInstldByMachineID(string machineID)
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<dpdwn_kitsInstld> kitsInstld = new List<dpdwn_kitsInstld>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                // begin empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables  
                //this is handled by a stored procedure on the sql server named dbo.bldSalesOppsTables
                con.Open();
                SqlCommand sqlcomm1 = new SqlCommand("dbo.bldSalesOppsTables", con);
                sqlcomm1.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcomm1.ExecuteNonQuery();
                //end empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables

                SqlCommand cmd = new SqlCommand("spGetKitsInstldByMachineID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@machineID",
                    Value = machineID
                };
                cmd.Parameters.Add(param);
                //con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_kitsInstld kitInstld = new dpdwn_kitsInstld();
                    //kitInstld.machineID = rdr["machineID"].ToString();
                    kitInstld.kitsInstld = rdr["kitID"].ToString();
                    kitsInstld.Add(kitInstld);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(kitsInstld));
        }
        [WebMethod]
        public void GetJobNosByCustomerCode(string customerCode)
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<vm_GetJobNosByCustomerCode> JobNos = new List<vm_GetJobNosByCustomerCode>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                // begin empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables  
                //this is handled by a stored procedure on the sql server named dbo.bldSalesOppsTables
                con.Open();
                //SqlCommand sqlcomm1 = new SqlCommand("dbo.bldSalesOppsTables", con);
                //sqlcomm1.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlcomm1.ExecuteNonQuery();
                //end empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables

                SqlCommand cmd = new SqlCommand("spGetJobNosByCustomerCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@customerCode",
                    Value = customerCode
                };
                cmd.Parameters.Add(param);
                //con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    vm_GetJobNosByCustomerCode JobNo = new vm_GetJobNosByCustomerCode();
                    //kaBnI.machineID = rdr["machineID_cEqpmt"].ToString();
                    JobNo.jobNo = rdr["jobNum"].ToString();
                    JobNo.customerCode = rdr["customerCode"].ToString();
                    JobNos.Add(JobNo);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(JobNos)); 
        }
        [WebMethod]
        public void GetKitInfoByKitID(string kitID)
        {
            string cs = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
            List<tbl_kit> KitInfos = new List<tbl_kit>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                // begin empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables  
                //this is handled by a stored procedure on the sql server named dbo.bldSalesOppsTables
                con.Open();
                //SqlCommand sqlcomm1 = new SqlCommand("dbo.bldSalesOppsTables", con);
                //sqlcomm1.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlcomm1.ExecuteNonQuery();
                //end empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables

                SqlCommand cmd = new SqlCommand("spGetKitInfoByKitID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@kitID",
                    Value = kitID
                };
                cmd.Parameters.Add(param);
                //con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tbl_kit KitInfo = new tbl_kit();

                    KitInfo.kitID = rdr["kitID"].ToString();
                    KitInfo.description = rdr["description"].ToString();
                    KitInfo.filePath = rdr["filePath"].ToString();
                    KitInfo.descKitItem_1 = rdr["descKitItem_1"].ToString();
                    KitInfo.partNoKitItem_1 = rdr["partNoKitItem_1"].ToString();
                    KitInfo.descKitItem_2 = rdr["descKitItem_2"].ToString();
                    KitInfo.partNoKitItem_2 = rdr["partNoKitItem_2"].ToString();
                    KitInfo.descKitItem_3 = rdr["descKitItem_3"].ToString();
                    KitInfo.partNoKitItem_3 = rdr["partNoKitItem_3"].ToString();
                    KitInfo.descKitItem_4 = rdr["descKitItem_4"].ToString();
                    KitInfo.partNoKitItem_4 = rdr["partNoKitItem_4"].ToString();
                    KitInfo.descKitItem_5 = rdr["descKitItem_5"].ToString();
                    KitInfo.partNoKitItem_5 = rdr["partNoKitItem_5"].ToString();

                    KitInfo.infoPackage = rdr["infoPackage"].ToString();
                    KitInfo.mechDrawing = rdr["mechDrawing"].ToString();
                    KitInfo.priceSheet = rdr["priceSheet"].ToString();

                    KitInfos.Add(KitInfo);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(KitInfos));
        }
    }
}
