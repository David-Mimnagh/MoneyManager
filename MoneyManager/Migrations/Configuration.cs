namespace MoneyManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoneyManager.DAL.BillContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MoneyManager.DAL.BillContext";
        }

        protected override void Seed(MoneyManager.DAL.BillContext context)
        {
        }
    }
}
