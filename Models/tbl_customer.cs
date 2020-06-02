namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_customer
    {
        public int id { get; set; }

        public string customerCode { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zipCode { get; set; }
    }
}
