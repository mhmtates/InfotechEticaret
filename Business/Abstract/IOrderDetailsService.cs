using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderDetailsService
    {

        // Orders => detail,Note,info
        IDataResult<IList<OrderDetailsDto>> GetAll(int id);
        OrderDetailsDto GetById(int Id);
        IResult Add(OrderDetailsDto data);
        IResult Update(OrderDetailsDto data);
        IResult Delete(int Id);
    }
}
