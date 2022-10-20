using DataAccess.Concrete.Contexts.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts.EntityFramework
{
    public class EticaretContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<AutoBasket> AutoBasket { get; set; }

        // Arayüz Katmanında ki JSON dosyamızdan bağlantı cümleciğini göndereceğiz.
        //public EticaretContext(DbContextOptions<EticaretContext> options):base(options)
        //{
        //    // Bussines => UIWeb => Bağlantıyı Alacak.
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RO1RB58\SQLEXPRESS;Database=infoEticaret;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bu Sınıfları ayarları baz alarak SQL'E gönderim Yapıyoruz.
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            modelBuilder.ApplyConfiguration(new OrderInfoMap());
            modelBuilder.ApplyConfiguration(new OrderNotesMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new PImagesMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
            modelBuilder.ApplyConfiguration(new TemBasketsMap());
            modelBuilder.ApplyConfiguration(new UsersAdminMap());
            modelBuilder.ApplyConfiguration(new VariantsMap());
        }
    }
}
