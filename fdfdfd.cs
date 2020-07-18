namespace allpax_sale_miner
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class fdfdfd : DbContext
    {
        public fdfdfd()
            : base("name=fdfdfd")
        {
        }

        public virtual DbSet<tbl_kit> tbl_kit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
