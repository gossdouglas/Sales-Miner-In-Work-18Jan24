namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("custEqpmtWkitsAvlbl")]
    public partial class custEqpmtWkitsAvlbl
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string customerCode_cEqpmt { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string eqpmtType_cEqpmt { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string model_cEqpmt { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string machineID_cEqpmt { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string jobNum_cEqpmt { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string eqpmtType_kitsAvlbl { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string model_kitsAvlbl { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string kitID_kitsAvlbl { get; set; }

        [StringLength(50)]
        public string name_customer { get; set; }
    }
}
