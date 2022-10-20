using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete.Repositories.EntityRepo
{
    class OrderInformationsRepository : EfEntityRepository<OrderInformations>, IOrderInformationsRepository
    {
        public OrderInformationsRepository(DbContext context) : base(context)
        {

        }
    }
}