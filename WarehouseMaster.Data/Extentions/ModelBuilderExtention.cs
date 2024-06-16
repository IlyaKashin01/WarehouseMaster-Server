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
            modelBuilder.ApplyConfiguration(new PersonalMessageConfig());
            modelBuilder.ApplyConfiguration(new GroupMessageConfig());
            modelBuilder.ApplyConfiguration(new GroupChatRoomConfig());
            modelBuilder.ApplyConfiguration(new GroupMemberConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new WarehouseConfig());
            modelBuilder.ApplyConfiguration(new ShipmentConfig());
            modelBuilder.ApplyConfiguration(new EntranceConfig());
            modelBuilder.ApplyConfiguration(new ProviderConfig());

            return modelBuilder;
        }

        public static ModelBuilder AddDeletedQueryFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staffer>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Category>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<SubCategory>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Product>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<PersonalMessage>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<GroupMessage>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<GroupChatRoom>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<GroupMember>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Person>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Warehouse>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Entrance>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Shipment>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Provider>().HasQueryFilter(e => e.DeleteDate == null);

            return modelBuilder;
        }
    }
}
