using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete.Repositories.EntityRepo
{
    public class AutoBasketRepository : EfEntityRepository<AutoBasket>, IAutoBasketRepository
    {
        public AutoBasketRepository(DbContext context) : base(context)
        {

        }
    }
}
