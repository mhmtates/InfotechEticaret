using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories
{
    public class PImagesRepository : EfEntityRepository<PImages>, IPImagesRepository
    {
        public PImagesRepository(DbContext context) : base(context)
        {

        }
    }
}
