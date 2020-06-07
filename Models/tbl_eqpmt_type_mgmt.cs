namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_eqpmt_type_mgmt")]
    public partial class tbl_eqpmt_type_mgmt
    {
        [Key]
        [StringLength(50)]
        public string eqpmtType { get; set; }

        public int id { get; set; }
    }
}
