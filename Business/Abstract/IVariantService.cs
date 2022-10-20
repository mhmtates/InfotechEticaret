using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVariantService
    {
        IDataResult<IList<VariantsDto>> GetAll(int id);
        VariantsDto GetById(int Id);
        IResult Add(VariantsDto data);
        IResult Update(VariantsDto data);
        IResult Delete(int Id);
    }
}
