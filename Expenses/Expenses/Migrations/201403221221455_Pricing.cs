namespace Expenses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pricing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpensePricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostPerSingleUser = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        CostPerOneQuantity = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Expenses", "Pricing_Id", c => c.Int());
            CreateIndex("dbo.Expenses", "Pricing_Id");
            AddForeignKey("dbo.Expenses", "Pricing_Id", "dbo.ExpensePricings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Pricing_Id", "dbo.ExpensePricings");
            DropIndex("dbo.Expenses", new[] { "Pricing_Id" });
            DropColumn("dbo.Expenses", "Pricing_Id");
            DropTable("dbo.ExpensePricings");
        }
    }
}
