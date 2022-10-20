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
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NameSurname).HasMaxLength(50);
            builder.Property(x => x.NameSurname).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15);
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.District).HasMaxLength(50);
            builder.Property(x => x.FullAddress).HasMaxLength(250);
            builder.Property(x => x.Password).HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Advert).IsRequired();
            builder.ToTable("Customers");
        }
    }
}
