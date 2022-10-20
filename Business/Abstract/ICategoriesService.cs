using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoriesService
    {
        IDataResult<IList<CategoriesDto>> GetAll(int Id);
        IDataResult<CategoriesDto> GetById(int Id);
        IResult Add(CategoriesDto data);
        IResult Update(CategoriesDto data);
        IResult Delete(int Id);
    }
}
