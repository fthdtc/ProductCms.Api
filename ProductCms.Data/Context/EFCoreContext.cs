using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductCms.Base.Constants;
using ProductCms.Base.Helper;
using ProductCms.Data.Entity; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProductCms.Data.Context
{
    public class EFCoreContext : DbContext
    {
        private readonly ConnectionStringSettings ConnectionStringSettings;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
         
        public EFCoreContext(DbContextOptions options, IOptions<ConnectionStringSettings> setting) : base(options)
        {
            ConnectionStringSettings = setting.Value;
        }
        public EFCoreContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(m => m.Id);
            builder.Entity<Category>().ToTable("t_category");

            builder.Entity<Product>().HasKey(m => m.Id);
            builder.Entity<Product>().ToTable("t_product"); 

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationHelper.GetConnectionString(AppSettingsConstant.ConnectionString.ProductCmsConnection);

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
