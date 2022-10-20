using Core.DataRepository.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrdersRepository : IEntityRepository<Orders>
    {
    }
}
