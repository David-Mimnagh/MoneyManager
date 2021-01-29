namespace MoneyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingQuickPurchaseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuickPurchases", "QuickPurchaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuickPurchases", "QuickPurchaseDate");
        }
    }
}
