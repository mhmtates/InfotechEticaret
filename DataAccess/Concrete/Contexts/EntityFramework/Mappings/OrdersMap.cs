using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Contexts.EntityFramework.Mappings
{
    public class OrdersMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CustomersId).IsRequired();
            builder.Property(c => c.OrderDate).IsRequired();
            builder.Property(c => c.CargoNumber).IsRequired();
            builder.Property(c => c.CargoNumber).HasMaxLength(50);
            builder.Property(c => c.CargoPrice).IsRequired();
            builder.Property(c => c.CargoPrice).HasColumnType("money");
            builder.Property(c => c.OrderStatus).IsRequired();
            builder.Property(c => c.OrderStatus).HasMaxLength(30); 
            builder.Property(c => c.TotalPrice).IsRequired();
            builder.Property(c => c.TotalPrice).HasColumnType("money");
            builder.Property(c => c.Kdv).IsRequired();
            builder.Property(c => c.TotalDiscount).IsRequired();
            builder.Property(c => c.TotalDiscount).HasColumnType("money");
            builder.Property(c => c.CouponPrice).IsRequired();
            builder.Property(c => c.CouponPrice).HasColumnType("money");

            builder.HasOne<Customers>(x => x.Customers).WithMany(c => c.Orders).HasForeignKey(a => a.CustomersId);
 

            builder.ToTable("Orders");
        }
    }
}
