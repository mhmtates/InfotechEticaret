using Core.Results.Abstract;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderInforService
    {
        IDataResult<IList<OrderInfoDto>> GetAll();
        IDataResult<OrderInfoDto> GetById(int Id);
        IResult Add(OrderInfoDto data);
        IResult Update(OrderInfoDto data);
        IResult Delete(int Id);
    }
}
