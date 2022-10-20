using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.Repositories.EntityRepo
{
    public class CustomerRepository : EfEntityRepository<Customers>, ICustomersRepository
    {
        // Bu kısımda Repository Sınıfımın Yapıcı Metot'una Parametre gönderiyoruz, yani veri tabanı Bağlantısını gönderiyoruz.
        public CustomerRepository(DbContext context) : base(context)
        {

        }
    }
}