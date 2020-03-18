using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using allpax_sale_miner.Models;

namespace allpax_sale_miner.Controllers
{
    public class EventTypeController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: KitMgmt
        public ActionResult Index()
        {
            allpax_sale_minerEntities entities = new allpax_sale_minerEntities();
            List<tbl_event_type> eventTypeMgmt = entities.tbl_event_type.ToList();

            return View(eventTypeMgmt.ToList());
        }
       
    }
}
