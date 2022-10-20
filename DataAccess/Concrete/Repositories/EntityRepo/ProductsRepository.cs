using Core.DataRepository.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class ProductsRepository: EfEntityRepository<Products>,IProductsRepository
    {
        public ProductsRepository(DbContext context) : base(context)
        {

        }

    }
}
