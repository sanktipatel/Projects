using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyCart.Models
{
    #region Migration Steps
    // Steps to create Code First Entity Framework
    // (1) Right Click -> Manage NuGet Packages
    // (2) Creare Classes 
    // (3) Create Context Class -> Inherit with DbContext -> Write DbSet<> for all classes
    // (4) Add Connection String Name in Constructor of Context Class
    // (5) Open Package Manager Console -> Run this Command "enable-migrations –EnableAutomaticMigration:$true"
    // (6) Open Package Manager Console -> Run this Command "add-migration 'First SampleDB Schema'"
    // (7) To Create Database -> Open Package Manager Console -> Run this Command "update-database -verbose"
    // To Rollback Migration -> update-database -TargetMigration:"Migration File Name"
    #endregion

    public class MyCartContext : DbContext
    {
        public MyCartContext() : base("name=cnStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyCartContext, MyCart.Migrations.Configuration>("cnStr"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example of using FluentAPI
            //modelBuilder.Entity<Country>()
            //     .HasMany<Customer>(c => c.Customer)
            //     .WithRequired(cus => cus.Country)
            //     .HasForeignKey(cus => cus.CountryID)
            //     .WillCascadeOnDelete(false);
        }

        public virtual DbSet<Login> LoginDetails { get; set; }
    }
}