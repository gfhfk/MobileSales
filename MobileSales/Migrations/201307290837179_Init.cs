namespace MobileSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteID = c.Int(nullable: false, identity: true),
                        RouteName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.RouteID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 150),
                        Comment = c.String(),
                        RouteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Routes", t => t.RouteID, cascadeDelete: true)
                .Index(t => t.RouteID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        ProductTypeName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .Index(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(),
                        TotalSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailsID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Customers", "RouteID", "dbo.Routes");
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropIndex("dbo.Customers", new[] { "RouteID" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Routes");
        }
        
    }
}
