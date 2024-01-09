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
            builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(x => x.Post).HasColumnName("post").IsRequired();
            builder.Property(x => x.WorkExperience).HasColumnName("work_experience");
            builder.Property(x => x.AccessLevel).HasColumnName("access_level").IsRequired();
            builder.Property(x => x.Salary).HasColumnName("salary").IsRequired();
        }
    }
}
