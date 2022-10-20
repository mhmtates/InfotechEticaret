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
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class OrderManager : IOrdersService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public OrderManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(OrderUpdateDto data)
        {
            try
            {
                works.OrdersRepository.Add(mapper.Map<Orders>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı.");
            }
            catch (Exception E)
            {
                string mesaj = E.Message;
                return new Result(ResultStatus.Error, "Kayıt Başarısız.");
            }
        }
        public IResult Delete(int Id)
        {
            try
            {
                works.OrdersRepository.Delete(works.OrdersRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }

        public IDataResult<IList<OrderUpdateListDto>> FiveTableGetAll(int Id)
        {
            IList<OrderUpdateListDto> data = new List<OrderUpdateListDto>();

            foreach (var item in works.OrdersRepository.GetAll(x=> x.Id == Id,a=> a.Customers, a => a.OrderDetails, a => a.OrderNotes, a => a.OrderInformations))
            {
                OrderUpdateListDto dt = new OrderUpdateListDto();
                dt = mapper.Map<OrderUpdateListDto>(item);  // Orders
                dt.CustomersUpdateDto = mapper.Map<CustomersUpdateDto>(item.Customers);// Customers
                dt.OrderDetailsDto = mapper.Map<IList<OrderDetailsDto>>(item.OrderDetails);//OrderDetail ICollection
                dt.OrderNotesDto = mapper.Map<IList<OrderNotesDto>>(item.OrderNotes);//OrderNotes ICollection
                dt.OrderInfoDto = mapper.Map<IList<OrderInfoDto>>(item.OrderInformations);//OrderInformations ICollection
                data.Add(dt);
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<OrderUpdateListDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<OrderUpdateListDto>>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }

        public IDataResult<IList<OrdersDto>> GetAll(string Durumu)
        {
            IList<OrdersDto> data = new List<OrdersDto>();
            foreach (var item in (Durumu != null) ? works.OrdersRepository.GetAll(x => x.OrderStatus == Durumu): works.OrdersRepository.GetAll())
            {
                data.Add(mapper.Map<OrdersDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<OrdersDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<OrdersDto>>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }
        public IDataResult<OrderUpdateDto> GetById(int Id)
        {
            var data = works.OrdersRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<OrderUpdateDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<OrderUpdateDto>(data));
            }
            else
            {
                return new DataResult<OrderUpdateDto>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }
        public IResult Update(OrderUpdateDto data)
        {
            try
            {
                works.OrdersRepository.Update(mapper.Map<Orders>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Güncelleme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Güncelleme Başarısız");
            }
        }

    }
}
