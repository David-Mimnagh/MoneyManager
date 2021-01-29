namespace MoneyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsBillPaidToBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill", "BillPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bill", "BillPaid");
        }
    }
}
