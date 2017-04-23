namespace Shipbob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_localDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        State = c.String(nullable: false, maxLength: 2),
                        PostalCode = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemColor = c.Int(nullable: false),
                        ItemType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TrackingId = c.String(nullable: false, maxLength: 100),
                        CreatedOrder = c.DateTime(nullable: false),
                        AddressEntity_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.AddressEntity_AddressId)
                .Index(t => t.AddressEntity_AddressId);
            
            CreateTable(
                "dbo.OrderEntityItemEntities",
                c => new
                    {
                        OrderEntity_OrderId = c.Int(nullable: false),
                        ItemEntity_ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderEntity_OrderId, t.ItemEntity_ItemId })
                .ForeignKey("dbo.Orders", t => t.OrderEntity_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemEntity_ItemId, cascadeDelete: true)
                .Index(t => t.OrderEntity_OrderId)
                .Index(t => t.ItemEntity_ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderEntityItemEntities", "ItemEntity_ItemId", "dbo.Items");
            DropForeignKey("dbo.OrderEntityItemEntities", "OrderEntity_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AddressEntity_AddressId", "dbo.Addresses");
            DropIndex("dbo.OrderEntityItemEntities", new[] { "ItemEntity_ItemId" });
            DropIndex("dbo.OrderEntityItemEntities", new[] { "OrderEntity_OrderId" });
            DropIndex("dbo.Orders", new[] { "AddressEntity_AddressId" });
            DropTable("dbo.OrderEntityItemEntities");
            DropTable("dbo.Orders");
            DropTable("dbo.Items");
            DropTable("dbo.Addresses");
        }
    }
}
