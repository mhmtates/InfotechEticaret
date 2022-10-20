using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITempBasketsService
    {
        IDataResult<IList<TempBasketDto>> GetAll(int CookiesID);
        IDataResult<TempBasketDto> GetById(int Id);
        IResult SepetArttirEksilt(int Id,bool islem);
        IResult AddUpdate(int ProductId,int CookiesID,int VaryantID);
        IResult Delete(int Id);
        IResult AutoBasketUpdate(AutoBasketDto data);
        IDataResult<AutoBasketDto> GetByIdAuto(int Id);
    }
}
