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
            db.Database.ExecuteSqlCommand("Insert into cmps411.tbl_kit Values({0},{1},{2},{3},{4},{5},{6},{7}, " +
                "'', '', '', '', '', '', '', '', '', '', '', '', '', '', '' )", 
                kitAdd.kitID, kitAdd.description, kitAdd.filePath, kitAdd.kitItem_1, kitAdd.kitItem_2, kitAdd.kitItem_3, kitAdd.kitItem_4, kitAdd.kitItem_5, 
                kitAdd.kitItem_6, kitAdd.kitItem_7, kitAdd.kitItem_8, kitAdd.kitItem_9, kitAdd.kitItem_10, kitAdd.kitItem_11, kitAdd.kitItem_12, 
                kitAdd.kitItem_13, kitAdd.kitItem_14, kitAdd.kitItem_15, kitAdd.kitItem_16, kitAdd.kitItem_17, kitAdd.kitItem_18, kitAdd.kitItem_19, kitAdd.kitItem_20);


            return new EmptyResult();
        }

        public ActionResult DeleteKit(tbl_kit kitDelete)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM cmps411.tbl_kit WHERE id=({0})", kitDelete.id);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateKit(tbl_kit kitUpdate)
        {
            //db.Database.ExecuteSqlCommand("UPDATE cmps411.tbl_kit SET kitID={0},description={1},filePath={2} WHERE id={3}",
            //    kitUpdate.kitID, kitUpdate.description, kitUpdate.filePath, kitUpdate.id);

            db.Database.ExecuteSqlCommand("UPDATE cmps411.tbl_kit SET kitID={0},description={1},filePath={2}, kitItem_1={4}, kitItem_2={5}, kitItem_3={6}, kitItem_4={7}, kitItem_5={8} " +
                "WHERE id={3}",
                kitUpdate.kitID, kitUpdate.description, kitUpdate.filePath, kitUpdate.id, kitUpdate.kitItem_1, kitUpdate.kitItem_2, kitUpdate.kitItem_3, kitUpdate.kitItem_4, kitUpdate.kitItem_5);

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
