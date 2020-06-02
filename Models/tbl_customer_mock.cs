namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_customer_mock")]
    public partial class tbl_customer_mock
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string customerCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string address { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string city { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2)]
        public string state { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(5)]
        public string zipCode { get; set; }
    }
}
