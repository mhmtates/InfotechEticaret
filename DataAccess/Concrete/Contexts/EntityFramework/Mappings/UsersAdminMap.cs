using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts.EntityFramework.Mappings
{
    public class UsersAdminMap : IEntityTypeConfiguration<UsersAdmin>
    {
        public void Configure(EntityTypeBuilder<UsersAdmin> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.NameSurName).IsRequired();
            builder.Property(c => c.NameSurName).HasMaxLength(50);
            builder.Property(c => c.EPosta).IsRequired();
            builder.Property(c => c.EPosta).HasMaxLength(80);
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(15);
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.Roles).IsRequired();
            builder.Property(c => c.Roles).HasMaxLength(25);
            builder.Property(c => c.Password).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(30);
            builder.ToTable("UsersAdmin");
        }
    }
}
