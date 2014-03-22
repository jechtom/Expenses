namespace Expenses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KioskModeFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "IsKioskModeAllowed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "IsKioskModeAllowed");
        }
    }
}
