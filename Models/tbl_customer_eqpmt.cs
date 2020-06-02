namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_customer_eqpmt")]
    public partial class tbl_customer_eqpmt
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string customerCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string machineID { get; set; }

        [Required]
        [StringLength(50)]
        public string eqpmtType { get; set; }

        public int id { get; set; }
    }
}
