using Microsoft.EntityFrameworkCore;
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
        public DbSet<Person> Users { get; set; }
        public DbSet<GroupChatRoom> Groups { get; set; }
        public DbSet<PersonalMessage> PersonalMessages { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Provider> Providers { get; set; }
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
