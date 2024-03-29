﻿using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Data.Extentions;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data
{
    public class AppDbContext: DbContext
    {
        #nullable disable
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Staffer> Staffers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddModelConfiguration();
            modelBuilder.AddDeletedQueryFilters();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
