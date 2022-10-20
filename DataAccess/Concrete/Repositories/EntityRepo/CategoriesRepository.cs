using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories
{
    public class CategoriesRepository : EfEntityRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(DbContext context) : base(context)
        {

        }
    }
}
