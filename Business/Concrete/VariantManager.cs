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
    public class VariantManager : IVariantService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;

        public VariantManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(VariantsDto variantsDto)
        {
            try
            {
                works.VariantRepository.Add(mapper.Map<Variants>(variantsDto));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Kayıt Başarısız");
            }
        }
        public IResult Delete(int id)
        {
            try
            {
                works.VariantRepository.Delete(works.VariantRepository.GetByIdFirst(x => x.Id == id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");

            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<VariantsDto>> GetAll(int id)
        {
            IList<VariantsDto> data = new List<VariantsDto>();
            foreach (var item in works.VariantRepository.GetAll(x => x.ProductsId == id))
            {
                data.Add(mapper.Map<VariantsDto>(item));

            }
            if (data.Count > 0)
            {
                return new DataResult<IList<VariantsDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<VariantsDto>>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }
        public VariantsDto GetById(int id)
        {
            return mapper.Map<VariantsDto>(works.VariantRepository.GetByIdFirst(x => x.Id == id));
        }
        public IResult Update(VariantsDto variantsDto)
        {
            try
            {
                works.VariantRepository.Update(mapper.Map<Variants>(variantsDto));
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
