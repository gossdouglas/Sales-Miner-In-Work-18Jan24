namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_eqpmt_type")]
    public partial class tbl_eqpmt_type
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string eqpmtType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string model { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string description { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
    }
}
