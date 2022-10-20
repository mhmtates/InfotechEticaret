using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories.EntityRepo
{
    class OrdersRepository : EfEntityRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(DbContext context) : base(context)
        {

        }
    }
}