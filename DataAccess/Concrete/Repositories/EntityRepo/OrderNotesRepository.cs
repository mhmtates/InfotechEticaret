using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories.EntityRepo
{
    class OrderNotesRepository : EfEntityRepository<OrderNotes>, IOrderNotesRepository
    {
        public OrderNotesRepository(DbContext context) : base(context)
        {

        }
    }
}
