using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.ModelConfig
{
    internal class StafferConfig: BaseEntityConfig<Staffer>
    {
        public override void Configure(EntityTypeBuilder<Staffer> builder)
        {
            base.Configure(builder);
            builder.ToTable("staffer");
            builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(x => x.MiddleName).HasColumnName("middle_name").IsRequired();
            builder.Property(x => x.Birthday).HasColumnName("birthday").IsRequired();
            builder.Property(x => x.Post).HasColumnName("post").IsRequired();
            builder.Property(x => x.Salary).HasColumnName("salary").IsRequired();
            builder.Property(x => x.QRCode).HasColumnName("qr_code");
            builder.Property(x => x.WarehouseId).HasColumnName("warehouse_id");
            builder.Property(x => x.AddedDate)
                .HasColumnName("added_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
