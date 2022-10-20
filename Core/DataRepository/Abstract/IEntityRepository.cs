using Core.Entitiess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataRepository.Abstract
{
    // Generic Type => Bağımsız Tip demektir. Eğer bir Sınıfa Generic Özelliği verilirse O sınıf içerisine istenilen sınıf ve veri tipi gönderilebilir demektir.

    // Sadece IEntity interface'sini miras alan sınıfları kabul edecektir.
    // new() => Buraya gelen Sınıflar aşağıda Türetilebilir Demektir.
    public interface IEntityRepository<TEntity>where TEntity:class,IEntity,new()
    {
        // Tek Satır Data Döndürecek.
        TEntity GetByIdFirst(Expression<Func<TEntity, bool>> filter);
        // (x=> x.Id) Linq To SQL sorgusunu kabul edebilir hale getiriyoruz.
        //filter == predicate == Where => Bunlar rasgele isimdir.
        // Bu Metot'u kullanırken buraya ilişkileri tabloları listeme isteği gönderebilirim anlamındadır.
        IList<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null, params Expression<Func<TEntity,object>>[] includeProperties);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(Expression<Func<TEntity, bool>> filter);
    }
}
