using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.Concrete.Contexts.EntityFramework.Mappings
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Piece).IsRequired();
            builder.Property(x => x.VName).IsRequired();
            builder.Property(x => x.VName).HasMaxLength(50);
            builder.Property(x => x.OrdersId).IsRequired();
            builder.Property(x => x.ProductsId).IsRequired();

            builder.HasOne<Orders>(x => x.Orders).WithMany(c => c.OrderDetails).HasForeignKey(f => f.OrdersId);

            builder.ToTable("OrderDetails");
        }
    }
}
