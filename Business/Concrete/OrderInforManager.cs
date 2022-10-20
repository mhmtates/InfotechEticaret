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

namespace Business.Concrete
{
    public class OrderInforManager: IOrderInforService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;

        public OrderInforManager(IMapper _mapper, IUnitOfWorks _work)
        {
            works = _work;
            mapper = _mapper;
        }

        public IResult Add(OrderInfoDto data)
        {
            try
            {
                works.OrderInformationsRepository.Add(mapper.Map<OrderInformations>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı.");
            }
            catch (Exception e)
            {
                string mesa = e.Message;
                return new Result(ResultStatus.Error, "Kayıt Başarısız.");
            }
        }

        public IResult Delete(int Id)
        {
            try
            {
                works.OrderInformationsRepository.Delete(works.OrderInformationsRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<OrderInfoDto>> GetAll()
        {
            IList<OrderInfoDto> data = new List<OrderInfoDto>();
            foreach (var item in works.OrderInformationsRepository.GetAll())
            {
                data.Add(mapper.Map<OrderInfoDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<OrderInfoDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<OrderInfoDto>>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }

        public IDataResult<OrderInfoDto> GetById(int Id)
        {
            var data = works.OrderInformationsRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<OrderInfoDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<OrderInfoDto>(data));
            }
            else
            {
                return new DataResult<OrderInfoDto>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }

        public IResult Update(OrderInfoDto data)
        {
            try
            {
                works.OrderInformationsRepository.Update(mapper.Map<OrderInformations>(data));
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
