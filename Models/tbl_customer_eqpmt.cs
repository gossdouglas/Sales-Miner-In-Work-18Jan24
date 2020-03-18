using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace allpax_sale_miner.Models
{
    public class tbl_customer_eqpmt
    {
        public string customerCode { get; set; }
        public string machineID { get; set; }
        public string jobNum { get; set; }
        public string eqpmtType { get; set; }
        public int id { get; set; }
    }
}