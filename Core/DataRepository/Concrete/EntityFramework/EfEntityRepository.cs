using Core.DataRepository.Abstract;
using Core.Entitiess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataRepository.Concrete.EntityFramework
{
    public class EfEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //FrameworkdCore => Veri Tabanı Crud İşlemlerini Sağlıyor.
        protected readonly DbContext context;
        public EfEntityRepository(DbContext _context)
        {
            context = _context;
        }
        public bool Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return true;
        }

        public bool Delete(Expression<Func<TEntity, bool>> filter)
        {
            context.Set<TEntity>().Remove(GetByIdFirst(filter));
            return true;
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties.Any())// İlişkili Sınıf Gönderilmiş mi ?
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public TEntity GetByIdFirst(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            return query.Where(filter).SingleOrDefault();
        }

        public bool Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return true;
        }
    }
}
