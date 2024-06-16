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
    public class EntranceConfig: BaseEntityConfig<Entrance>
    {
        public override void Configure(EntityTypeBuilder<Entrance> builder)
        {
            base.Configure(builder);
            builder.ToTable("entrance");
            builder.Property(x => x.WarehouseId).HasColumnName("warehouse_id");
            builder.Property(x => x.ProductId).HasColumnName("product_id");
            builder.Property(x => x.EntranceDate).HasColumnName("entrance_date");
            builder.Property(x => x.StafferId).HasColumnName("staffer_id");
            builder.Property(x => x.Quantity).HasColumnName("quantity");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.AcceptDate).HasColumnName("accept_date");
        }
    }
}
