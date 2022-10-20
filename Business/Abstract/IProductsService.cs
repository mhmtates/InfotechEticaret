using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IProductsService
    {
        // Her zaman Kullanıcıya Bir Tabloda Bütün Sütunlar Gönderilmez.
        // Entities'teki tablolara benzer Bir Yapı daha kurulur.
        // DTO => Data Transfer Object
        IDataResult<IList<ProductsDto>> GetAll();
        IDataResult<IList<ProductsDto>> KategoriyeGoreUrunGetirme(int CategoryId);
        IDataResult<IList<ProductsDto>> GetAllKampanya();
        IDataResult<ProductsUpdateDto> GetById(int Id);
        IResult Add(ProductsUpdateDto data);
        IResult Update(ProductsUpdateDto data);
        IResult Delete(int Id);
        IDataResult<int> SearchId(string Name, decimal Price, int Stock);
    }
}
