namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_event_type
    {
        public int id { get; set; }

        public string eventID { get; set; }

        public string eventType { get; set; }
    }
}
