using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories
{
    public class VariantRepository : EfEntityRepository<Variants>, IVariantRepository
    {
        public VariantRepository(DbContext context) : base(context)
        {

        }
    }
}
