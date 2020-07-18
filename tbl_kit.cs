namespace allpax_sale_miner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmps411.tbl_kit")]
    public partial class tbl_kit
    {
        [Key]
        [StringLength(50)]
        public string kitID { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [Required]
        [StringLength(500)]
        public string filePath { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        public string kitItem_1 { get; set; }

        [StringLength(50)]
        public string kitItem_2 { get; set; }

        [StringLength(50)]
        public string kitItem_3 { get; set; }

        [StringLength(50)]
        public string kitItem_4 { get; set; }

        [StringLength(50)]
        public string kitItem_5 { get; set; }

        [StringLength(50)]
        public string kitItem_6 { get; set; }

        [StringLength(50)]
        public string kitItem_7 { get; set; }

        [StringLength(50)]
        public string kitItem_8 { get; set; }

        [StringLength(50)]
        public string kitItem_9 { get; set; }

        [StringLength(50)]
        public string kitItem_10 { get; set; }

        [StringLength(50)]
        public string kitItem_11 { get; set; }

        [StringLength(50)]
        public string kitItem_12 { get; set; }

        [StringLength(50)]
        public string kitItem_13 { get; set; }

        [StringLength(50)]
        public string kitItem_14 { get; set; }

        [StringLength(50)]
        public string kitItem_15 { get; set; }

        [StringLength(50)]
        public string kitItem_16 { get; set; }

        [StringLength(50)]
        public string kitItem_17 { get; set; }

        [StringLength(50)]
        public string kitItem_18 { get; set; }

        [StringLength(50)]
        public string kitItem_19 { get; set; }

        [StringLength(50)]
        public string kitItem_20 { get; set; }
    }
}
