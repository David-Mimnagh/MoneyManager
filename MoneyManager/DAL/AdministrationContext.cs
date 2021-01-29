using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MoneyManager.DAL
{
    public class AdministrationContext : DbContext
    {

        public AdministrationContext() : base("AdministrationContext")
        {
        }

        public DbSet<Administration> Administration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<AdministrationContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}