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
    public class ProviderConfig: BaseEntityConfig<Provider>
    {
        public override void Configure(EntityTypeBuilder<Provider> builder)
        {
            base.Configure(builder);
            builder.ToTable("provider");
            builder.Property(x => x.FullName).HasColumnName("full_name");
            builder.Property(x => x.Company).HasColumnName("company");
            builder.Property(x => x.Phone).HasColumnName("phone");
            builder.Property(x => x.Email).HasColumnName("email");
        }
    }
}
