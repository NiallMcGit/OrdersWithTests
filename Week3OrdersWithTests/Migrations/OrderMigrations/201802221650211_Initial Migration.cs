namespace Week3OrdersWithTests.Migrations.OrderMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CreditRating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        EnteredBy = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ReorderLevel = c.Int(nullable: false),
                        ReorderQuantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        StockOnHand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.OrderLines", new[] { "ProductID" });
            DropIndex("dbo.OrderLines", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
