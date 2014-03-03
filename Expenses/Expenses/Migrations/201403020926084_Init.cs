namespace Expenses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseIcons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Data = c.Binary(),
                        ContentType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Creator_Id = c.Int(nullable: false),
                        Expense_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id, cascadeDelete: false)
                .ForeignKey("dbo.Expenses", t => t.Expense_Id, cascadeDelete: true)
                .Index(t => t.Creator_Id)
                .Index(t => t.Expense_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AmountType = c.Byte(nullable: false),
                        Creator_Id = c.Int(nullable: false),
                        Icon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id, cascadeDelete: false)
                .ForeignKey("dbo.ExpenseIcons", t => t.Icon_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Icon_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItems", "Expense_Id", "dbo.Expenses");
            DropForeignKey("dbo.ExpenseItems", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Expenses", "Icon_Id", "dbo.ExpenseIcons");
            DropForeignKey("dbo.Expenses", "Creator_Id", "dbo.Users");
            DropIndex("dbo.ExpenseItems", new[] { "Expense_Id" });
            DropIndex("dbo.ExpenseItems", new[] { "Creator_Id" });
            DropIndex("dbo.Expenses", new[] { "Icon_Id" });
            DropIndex("dbo.Expenses", new[] { "Creator_Id" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Users");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseIcons");
        }
    }
}
