using Core.Results.Abstract;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IOrdersService
    {
        IDataResult<IList<OrderUpdateListDto>> FiveTableGetAll(int Id); // İlişkilendirilmiş 5 Tablo getirecek.
        IDataResult<IList<OrdersDto>> GetAll(string Durumu);
        IDataResult<OrderUpdateDto> GetById(int Id);
        IResult Add(OrderUpdateDto data);
        IResult Update(OrderUpdateDto data);
        IResult Delete(int Id);
    }
}
