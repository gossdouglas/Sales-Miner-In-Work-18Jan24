namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_customer_event
    {
        public int id { get; set; }

        public string customerCode { get; set; }

        public string eventType { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int? tbl_customer_id { get; set; }
    }
}
