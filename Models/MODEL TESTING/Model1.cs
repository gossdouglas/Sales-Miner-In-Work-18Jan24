using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace allpax_sale_miner.Models.MODEL_TESTING
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tbl_customer> tbl_customer { get; set; }
        public virtual DbSet<tbl_customer_eqpmt> tbl_customer_eqpmt { get; set; }
        public virtual DbSet<tbl_customer_event> tbl_customer_event { get; set; }
        public virtual DbSet<tbl_eqpmt_kits_avlbl> tbl_eqpmt_kits_avlbl { get; set; }
        public virtual DbSet<tbl_eqpmt_kits_current> tbl_eqpmt_kits_current { get; set; }
        public virtual DbSet<tbl_eqpmt_type> tbl_eqpmt_type { get; set; }
        public virtual DbSet<tbl_eqpmt_type_mgmt> tbl_eqpmt_type_mgmt { get; set; }
        public virtual DbSet<tbl_event_type> tbl_event_type { get; set; }
        public virtual DbSet<tbl_kit> tbl_kit { get; set; }
        public virtual DbSet<tbl_sales_opportunities> tbl_sales_opportunities { get; set; }
        public virtual DbSet<custEqpmtWkitsAvlbl> custEqpmtWkitsAvlbls { get; set; }
        public virtual DbSet<custEqpmtWkitsInstld> custEqpmtWkitsInstlds { get; set; }
        public virtual DbSet<tbl_states> tbl_states { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.zipCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .HasMany(e => e.tbl_customer_eqpmt)
                .WithRequired(e => e.tbl_customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_customer>()
                .HasMany(e => e.tbl_customer_event)
                .WithRequired(e => e.tbl_customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_customer>()
                .HasMany(e => e.tbl_sales_opportunities)
                .WithRequired(e => e.tbl_customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_customer_eqpmt>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_eqpmt>()
                .Property(e => e.eqpmtType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_eqpmt>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_eqpmt>()
                .Property(e => e.machineID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_eqpmt>()
                .Property(e => e.jobNum)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_event>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_event>()
                .Property(e => e.eventType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer_event>()
                .Property(e => e.eventID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_kits_avlbl>()
                .Property(e => e.eqpmtType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_kits_avlbl>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_kits_avlbl>()
                .Property(e => e.kitID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_kits_current>()
                .Property(e => e.machineID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_kits_current>()
                .Property(e => e.kitID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_type>()
                .Property(e => e.eqpmtType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_type>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_type>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_type_mgmt>()
                .Property(e => e.eqpmtType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_eqpmt_type_mgmt>()
                .HasMany(e => e.tbl_customer_eqpmt)
                .WithRequired(e => e.tbl_eqpmt_type_mgmt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_eqpmt_type_mgmt>()
                .HasMany(e => e.tbl_eqpmt_type)
                .WithRequired(e => e.tbl_eqpmt_type_mgmt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_event_type>()
                .Property(e => e.eventID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_event_type>()
                .Property(e => e.eventType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.kitID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.filePath)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_1)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_1)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_2)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_2)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_3)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_3)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_4)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_4)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_5)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_5)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_6)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_6)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_7)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_7)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_8)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_8)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_9)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_9)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.descKitItem_10)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.partNoKitItem_10)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.infoPackage)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.mechDrawing)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .Property(e => e.priceSheet)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kit>()
                .HasMany(e => e.tbl_eqpmt_kits_avlbl)
                .WithRequired(e => e.tbl_kit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_sales_opportunities>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_sales_opportunities>()
                .Property(e => e.machineID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_sales_opportunities>()
                .Property(e => e.kitID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_sales_opportunities>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_sales_opportunities>()
                .Property(e => e.supportFiles)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.customerCode_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.eqpmtType_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.model_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.machineID_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.jobNum_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.eqpmtType_kitsAvlbl)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.model_kitsAvlbl)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.kitID_kitsAvlbl)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsAvlbl>()
                .Property(e => e.name_customer)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.customerCode_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.eqpmtType_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.model_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.machineID_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.jobNum_cEqpmt)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.machineID_kitsCurrent)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.kitID_kitsCurrent)
                .IsUnicode(false);

            modelBuilder.Entity<custEqpmtWkitsInstld>()
                .Property(e => e.name_customer)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_states>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_states>()
                .Property(e => e.abbrev)
                .IsUnicode(false);
        }
    }
}
