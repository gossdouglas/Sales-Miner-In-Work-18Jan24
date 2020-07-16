﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using allpax_sale_miner.Models.Dropdown_Models;
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
                    kaBnIs.Add(kaBnI);
                }               
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(kaBnIs));            
        }
    }
}