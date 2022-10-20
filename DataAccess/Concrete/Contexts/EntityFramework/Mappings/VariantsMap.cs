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
    public class VariantsMap : IEntityTypeConfiguration<Variants>
    {
        public void Configure(EntityTypeBuilder<Variants> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.GroupName).HasMaxLength(50);
            builder.Property(x => x.GroupName).IsRequired(true);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Price).IsRequired(true);

            builder.HasOne<Products>(x => x.Products).WithMany(x => x.Variants).HasForeignKey(x=> x.ProductsId);
        }
    }
}
