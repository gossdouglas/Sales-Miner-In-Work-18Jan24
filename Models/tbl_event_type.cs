namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_event_type")]
    public partial class tbl_event_type
    {
        [StringLength(50)]
        public string eventID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string eventType { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
    }
}
