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
    internal class SubCategoryConfig: BaseEntityConfig<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure(builder);
            builder.ToTable("subcategory");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.StafferId).HasColumnName("staffer_id").IsRequired();
            builder.Property(x => x.CategoryId).HasColumnName("category_id").IsRequired();
            builder.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
