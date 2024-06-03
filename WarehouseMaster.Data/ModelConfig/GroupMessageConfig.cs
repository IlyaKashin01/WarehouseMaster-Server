﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.ModelConfig
{
    public class GroupMessageConfig: BaseEntityMessageConfig<GroupMessage>
    {
        public override void Configure(EntityTypeBuilder<GroupMessage> builder)
        {
            base.Configure(builder);
            builder.ToTable("group_message");
            builder.Property(e => e.GroupId).HasColumnName("group_id");
        }
    }
}
