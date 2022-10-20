using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.Repositories.EntityRepo
{
    public class OrderDetailsRepository : EfEntityRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(DbContext context) : base(context)
        {

        }
    }
}