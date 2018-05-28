using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Entities;

namespace Users.Infra.Persistence.Context.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(x => x.HashPassword)
                .HasColumnType("VARCHAR(350)")
                .IsRequired();
        }
    }
}
