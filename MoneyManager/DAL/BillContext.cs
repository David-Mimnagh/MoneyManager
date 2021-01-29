using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MoneyManager.DAL
{
    public class BillContext : DbContext
    {

        public BillContext() : base("BillContext")
        {
        }

        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}