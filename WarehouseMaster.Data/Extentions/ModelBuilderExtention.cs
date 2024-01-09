using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Data.ModelConfig;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Extentions
{
    public static class ModelBuilderExtention
    {
        public static ModelBuilder AddModelConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StafferConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new SubCategoryConfig());

            return modelBuilder;
        }

        public static ModelBuilder AddDeletedQueryFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staffer>().HasQueryFilter(e => e.Deleted == null);
            modelBuilder.Entity<Category>().HasQueryFilter(e => e.Deleted == null);
            modelBuilder.Entity<SubCategory>().HasQueryFilter(e => e.Deleted == null);
            modelBuilder.Entity<Product>().HasQueryFilter(e => e.Deleted == null);

            return modelBuilder;
        }
    }
}
