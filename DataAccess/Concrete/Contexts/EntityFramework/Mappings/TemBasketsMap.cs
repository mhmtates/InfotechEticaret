using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts.EntityFramework.Mappings
{
    public class TemBasketsMap : IEntityTypeConfiguration<TempBaskets>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TempBaskets> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.ProductsId).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.Piece).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Price).HasColumnType("money");
            builder.Property(c => c.VName).IsRequired();
            builder.Property(c => c.VName).HasMaxLength(50);
            builder.Property(c => c.CustomersId).IsRequired();
            builder.Property(c => c.CookiesID).IsRequired();

            builder.ToTable("TempBaskets");

        }
    }
}
