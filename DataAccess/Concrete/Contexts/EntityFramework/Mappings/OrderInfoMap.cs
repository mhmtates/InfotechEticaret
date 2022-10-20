using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Contexts.EntityFramework.Mappings
{
    public class OrderInfoMap : IEntityTypeConfiguration<OrderInformations>
    {
        public void Configure(EntityTypeBuilder<OrderInformations> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Sms).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(150);
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.InfoDate).IsRequired();
            builder.Property(x => x.OrdersId).IsRequired();
            builder.Property(x => x.CustomersId).IsRequired();

            builder.HasOne<Orders>(x => x.Orders).WithMany(c => c.OrderInformations).HasForeignKey(f => f.OrdersId);
            builder.ToTable("OrderInformations");
        }
    }
}
