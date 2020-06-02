namespace allpax_sale_miner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_customer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customerCode = c.String(),
                        name = c.String(),
                        address = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zipCode = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_customer_eqpmt",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        machineID = c.String(),
                        customerCode = c.String(),
                        eqpmtType = c.String(),
                        tbl_customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_customer", t => t.tbl_customer_id)
                .Index(t => t.tbl_customer_id);
            
            CreateTable(
                "dbo.tbl_customer_event",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customerCode = c.String(),
                        eventType = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        tbl_customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_customer", t => t.tbl_customer_id)
                .Index(t => t.tbl_customer_id);
            
            CreateTable(
                "dbo.tbl_eqpmt_kits_avlbl",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eqpmtType = c.String(),
                        kitID = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_eqpmt_kits_current",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        machineID = c.String(),
                        kitID = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_eqpmt_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eqpmtType = c.String(),
                        model = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_eqpmt_type_mgmt",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eqpmtType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_event_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eventID = c.String(),
                        eventType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_kit",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        kitID = c.String(),
                        description = c.String(),
                        filePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_customer_event", "tbl_customer_id", "dbo.tbl_customer");
            DropForeignKey("dbo.tbl_customer_eqpmt", "tbl_customer_id", "dbo.tbl_customer");
            DropIndex("dbo.tbl_customer_event", new[] { "tbl_customer_id" });
            DropIndex("dbo.tbl_customer_eqpmt", new[] { "tbl_customer_id" });
            DropTable("dbo.tbl_kit");
            DropTable("dbo.tbl_event_type");
            DropTable("dbo.tbl_eqpmt_type_mgmt");
            DropTable("dbo.tbl_eqpmt_type");
            DropTable("dbo.tbl_eqpmt_kits_current");
            DropTable("dbo.tbl_eqpmt_kits_avlbl");
            DropTable("dbo.tbl_customer_event");
            DropTable("dbo.tbl_customer_eqpmt");
            DropTable("dbo.tbl_customer");
        }
    }
}
