using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories.EntityRepo
{
    public class UsersAdminRepository : EfEntityRepository<UsersAdmin>, IUsersAdminRepository
    {
        public UsersAdminRepository(DbContext context) : base(context)
        {

        }
    }
}

