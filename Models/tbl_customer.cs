namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_customer")]
    public partial class tbl_customer
    {
        [Key]
        [StringLength(3)]
        public string customerCode { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(2)]
        public string state { get; set; }

        [Required]
        [StringLength(5)]
        public string zipCode { get; set; }

        public int id { get; set; }
    }
}
