using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.ModelConfig
{
    internal class CategoryConfig: BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("category");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.StafferId).HasColumnName("staffer_id").IsRequired();
            builder.Property(x => x.StafferId).HasColumnName("staffer_id");
            builder.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
