using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyManager.DAL
{
    public class QuickPurchaseContext : DbContext
    {

        public QuickPurchaseContext() : base("QuickPurchaseContext")
        {
        }

        public DbSet<QuickPurchase> QuickPurchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<QuickPurchaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}