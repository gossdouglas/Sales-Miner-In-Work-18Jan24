namespace allpax_sale_miner.Models.MODEL_TESTING
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_eqpmt_kits_current
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string machineID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string kitID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}
