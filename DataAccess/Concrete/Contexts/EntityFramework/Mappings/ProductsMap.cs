using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Contexts.EntityFramework
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x => x.Id);// Primary Key
            builder.Property(x => x.Id).ValueGeneratedOnAdd();// Otomatik Artan.
            builder.Property(x => x.Keywords).HasMaxLength(180);
            builder.Property(x => x.Keywords).IsRequired(); // Boş Bırakılamaz.
            builder.Property(x => x.Description).HasMaxLength(180);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Discount).HasColumnType("money");
            builder.Property(x => x.Discount).IsRequired();
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Explanation).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Explanation).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.MainImages).HasMaxLength(150);
            builder.Property(x => x.MainImages).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CategoriesId).IsRequired();
            // İlişkilendirme.
            builder.HasOne<Categories>(x => x.Categories).WithMany(c => c.Products).HasForeignKey(a => a.CategoriesId);



            builder.ToTable("Products");

        }
    }
}
