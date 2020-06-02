namespace allpax_sale_miner.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class allpax_sale_minerEntities : DbContext
    {
        public allpax_sale_minerEntities()
            : base("name=allpax_sale_minerEntities")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<tbl_customer_eqpmt> tbl_customer_eqpmt { get; set; }
        public virtual DbSet<tbl_customer_event> tbl_customer_event { get; set; }
        public virtual DbSet<tbl_eqpmt_kits_avlbl> tbl_eqpmt_kits_avlbl { get; set; }
        public virtual DbSet<tbl_eqpmt_kits_current> tbl_eqpmt_kits_current { get; set; }
        public virtual DbSet<tbl_eqpmt_type> tbl_eqpmt_type { get; set; }
        public virtual DbSet<tbl_eqpmt_type_mgmt> tbl_eqpmt_type_mgmt { get; set; }
        public virtual DbSet<tbl_event_type> tbl_event_type { get; set; }
        public virtual DbSet<tbl_kit> tbl_kit { get; set; }
        public virtual DbSet<tbl_customer> tbl_customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_customer_eqpmt>()
                .Property(e => e.machineID)
                .IsFixedLength();

            modelBuilder.Entity<tbl_customer_eqpmt>()
                .HasOptional(e => e.tbl_customer_eqpmt1)
                .WithRequired(e => e.tbl_customer_eqpmt2);
        }
    }
}
