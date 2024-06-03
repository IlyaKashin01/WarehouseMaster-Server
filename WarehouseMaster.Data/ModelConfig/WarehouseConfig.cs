using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.ModelConfig
{
    public class WarehouseConfig : BaseEntityConfig<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            base.Configure(builder);
            builder.ToTable("warehouse");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Purpose).HasColumnName("purpose").IsRequired();
            builder.Property(x => x.Address).HasColumnName("address").IsRequired();
            builder.Property(x => x.Square).HasColumnName("square").IsRequired();
            builder.Property(x => x.CountEmployees).HasColumnName("count_employees").IsRequired();
            builder.Property(x => x.CountTechnic).HasColumnName("count_technic").IsRequired();
            builder.Property(x => x.Capacity).HasColumnName("capacity").IsRequired();
            builder.Property(x => x.Occupancy).HasColumnName("occupancy").IsRequired();
            builder.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
