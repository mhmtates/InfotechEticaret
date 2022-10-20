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
    public class OrderNotesMap : IEntityTypeConfiguration<OrderNotes>
    {
        public void Configure(EntityTypeBuilder<OrderNotes> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.OrdersId).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(150);
            builder.Property(x => x.Notes).IsRequired();
            builder.Property(x => x.NotDate).IsRequired();
            builder.HasOne<Orders>(x => x.Orders).WithMany(c => c.OrderNotes).HasForeignKey(f => f.OrdersId);
            builder.ToTable("OrderNotes");
        }
    }
}
