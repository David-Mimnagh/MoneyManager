namespace MoneyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BillAmount = c.Double(nullable: false),
                        BillName = c.String(),
                        BillInformation = c.String(),
                        BillDueDay = c.Int(nullable: false),
                        IsMandatoryBill = c.Boolean(nullable: false),
                        IsSavingsAccount = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bill");
        }
    }
}
