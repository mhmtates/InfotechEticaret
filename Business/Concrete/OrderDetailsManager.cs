using AutoMapper;
using Business.Abstract;
using Core.Results.Abstract;
using Core.Results.ComplexTypes;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailsManager : IOrderDetailsService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public OrderDetailsManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(OrderDetailsDto data)
        {
            try
            {
                works.OrderDetailsRepository.Add(mapper.Map<OrderDetails>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı.");
            }
            catch (Exception e)
            {
                string dataa = e.Message;
                return new Result(ResultStatus.Error, "Kayıt Başarısız.");
            }
        }

        public IResult Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<OrderDetailsDto>> GetAll(int id)
        {
            IList<OrderDetailsDto> data = new List<OrderDetailsDto>();
            foreach (var item in works.OrderDetailsRepository.GetAll(x=> x.OrdersId== id))
            {
                data.Add(mapper.Map<OrderDetailsDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<OrderDetailsDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<OrderDetailsDto>>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }

        public OrderDetailsDto GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(OrderDetailsDto data)
        {
            throw new NotImplementedException();
        }
    }
}
