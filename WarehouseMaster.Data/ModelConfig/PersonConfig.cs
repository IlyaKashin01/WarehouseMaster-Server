﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Data.ModelConfig
{
    public class PersonConfig: BaseEntityConfig<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.ToTable("person");
            builder.Property(e => e.Login).HasColumnName("login");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.Avatar).HasColumnName("avatar");
            builder.Property(e => e.FirstName).HasColumnName("first_name");
            builder.Property(e => e.LastName).HasColumnName("last_name");
            builder.Property(e => e.MiddleName).HasColumnName("middle_name");
            builder.Property(e => e.ResetPassCode).HasColumnName("reset_pass_code");
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
            builder.Property(e => e.Role).HasColumnName("role");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registration_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
