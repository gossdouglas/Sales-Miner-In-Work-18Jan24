namespace allpax_sale_miner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_customer_eqpmt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string customerCode { get; set; }

        [Required]
        public string eqpmtType { get; set; }

        [Key]
        [StringLength(50)]
        public string machineID { get; set; }

        public virtual tbl_customer_eqpmt tbl_customer_eqpmt1 { get; set; }

        public virtual tbl_customer_eqpmt tbl_customer_eqpmt2 { get; set; }
    }
}
