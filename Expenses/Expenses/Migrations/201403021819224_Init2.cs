namespace Expenses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "Icon_Id", "dbo.ExpenseIcons");
            DropIndex("dbo.Expenses", new[] { "Icon_Id" });
            AlterColumn("dbo.Expenses", "Icon_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenses", "Icon_Id");
            AddForeignKey("dbo.Expenses", "Icon_Id", "dbo.ExpenseIcons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Icon_Id", "dbo.ExpenseIcons");
            DropIndex("dbo.Expenses", new[] { "Icon_Id" });
            AlterColumn("dbo.Expenses", "Icon_Id", c => c.Int());
            CreateIndex("dbo.Expenses", "Icon_Id");
            AddForeignKey("dbo.Expenses", "Icon_Id", "dbo.ExpenseIcons", "Id");
        }
    }
}
