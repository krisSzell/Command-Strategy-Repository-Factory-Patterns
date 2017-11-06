using CarWashServiceBrowserFull.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarWashServiceBrowserFull.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() :base("AppDbContext")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Service> Services { get; set; }
    }
}