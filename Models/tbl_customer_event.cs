namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_customer_event")]
    public partial class tbl_customer_event
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string customerCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string eventType { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime startDate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime endDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
    }
}
