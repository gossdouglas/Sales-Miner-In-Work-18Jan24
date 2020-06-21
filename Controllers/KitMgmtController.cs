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
    public class KitMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: KitMgmt
        public ActionResult Index()
        {
            var sql = db.tbl_kit.SqlQuery("SELECT * from cmps411.tbl_kit").ToList();

            return View(sql.ToList());
        }
        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddKit(tbl_kit kitAdd)
        {
            db.Database.ExecuteSqlCommand("Insert into cmps411.tbl_kit Values({0},{1},{2})", kitAdd.kitID, kitAdd.description, kitAdd.filePath);
            return new EmptyResult();
        }

        public ActionResult DeleteKit(tbl_kit kitDelete)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM cmps411.tbl_kit WHERE id=({0})", kitDelete.id);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateKit(tbl_kit kitUpdate)
        {
            db.Database.ExecuteSqlCommand("UPDATE cmps411.tbl_kit SET kitID={0},description={1},filePath={2} WHERE id={3}",
                kitUpdate.kitID, kitUpdate.description, kitUpdate.filePath, kitUpdate.id);

            return RedirectToAction("Index");
        }


        //end CMPS 411 controller code

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
