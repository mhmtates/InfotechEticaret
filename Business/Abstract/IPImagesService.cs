using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPImagesService
    {
        IDataResult<IList<PImagesDto>> GetAll(int id);
        PImagesDto GetByIdFirst(int id);
        IResult Add(PImagesDto data);
        IResult Update(PImagesDto data);
        IResult Delete(int Id);
    }
}
