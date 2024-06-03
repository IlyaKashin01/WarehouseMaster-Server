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
    internal class ProductConfig: BaseEntityConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.ToTable("product");
            builder.Property(p => p.Name).HasColumnName("name").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").IsRequired();
            builder.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();
            builder.Property(p => p.SubcategoryId).HasColumnName("subcategory_id");
            builder.Property(p => p.Cost).HasColumnName("cost").IsRequired();
            builder.Property(p => p.Count).HasColumnName("count").IsRequired();
            builder.Property(p => p.StafferId).HasColumnName("staffer_id").IsRequired();
            builder.Property(p => p.QRCode).HasColumnName("qr_code").IsRequired();
            builder.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
