using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Contexts.EntityFramework
{
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.Id);// Primary Key
            builder.Property(x => x.Id).ValueGeneratedOnAdd();// Otomatik Artan.
            builder.Property(x => x.Name).HasMaxLength(180);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).IsRequired(); // Boş Bırakılamaz.
            builder.Property(x => x.Status).IsRequired();
            builder.ToTable("Categories");

            // Ön Tanımlı Veri Eklemek istiyor isek :
            // Veritabanı oluşturulurken içerisine otomatik veri atma işlemi.
            builder.HasData(
                new Categories
                {
                    Id = 1,
                    Name = "Teknoloji",
                    ParentId = 0,
                    Status = true,
                },
                   new Categories
                   {
                       Id = 2,
                       Name = "Ev Aletleri",
                       ParentId = 0,
                       Status = true,
                   }
                );

            // intercepting filter
            // flyweight
            // front controller
            // Singleton
            // Unit OF Works
            // Chain of Responsibility 
        }
    }
}
