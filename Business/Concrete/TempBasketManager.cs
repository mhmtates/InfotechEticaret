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
    public class TempBasketManager : ITempBasketsService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;

        public TempBasketManager(IMapper _mapper, IUnitOfWorks _work)
        {
            works = _work;
            mapper = _mapper;
        }

        public IResult AddUpdate(int ProductId, int CookiesID, int VaryantID)
        {
            try
            {
                // CookiesID(1) olan kullanıcı daha önce bu ürünü sepete eklememiş ise sepete eklenecek
                if (works.TempBasketRepository.GetByIdFirst(x => x.ProductsId == ProductId && x.CookiesID == CookiesID) == null)
                {
                    var FindProduct = works.ProductsRepository.GetByIdFirst(x => x.Id == ProductId);
                    TempBasketDto dto = new TempBasketDto();
                    dto.ProductsId = FindProduct.Id;
                    dto.Name = FindProduct.Name;
                    dto.Piece = 1;
                    dto.CookiesID = CookiesID;

                    if (VaryantID == 0)
                    {
                        dto.VName = "";
                        dto.Price = FindProduct.Price;
                    }
                    else
                    {
                        var BulunanVaryant = works.VariantRepository.GetByIdFirst(x=> x.Id == VaryantID);
                        dto.VName = BulunanVaryant.Name;
                        dto.Price = BulunanVaryant.Price;

                    }
                    dto.MainImages = FindProduct.MainImages;
                    works.TempBasketRepository.Add(mapper.Map<TempBaskets>(dto));
                    works.SaveChanges();
                    return new Result(ResultStatus.Success, "Ürün Sepete Eklenmiştir..");
                }
                // Eklemiş ise adet güncellemesi gerçekleşecek.
                else
                {
                    var BulunanUrun = works.TempBasketRepository.GetByIdFirst(x => x.ProductsId == ProductId && x.CookiesID == CookiesID);
                    BulunanUrun.Piece++;
                    works.TempBasketRepository.Update(BulunanUrun);
                    works.SaveChanges();
                    return new Result(ResultStatus.Success, "Ürün'ün Adeti Arttırılmıştır.");
                }
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Kayıt Başarısız.");
            }
        }
        public IResult Delete(int Id)
        {
            try
            {
                works.TempBasketRepository.Delete(works.TempBasketRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<TempBasketDto>> GetAll(int CookiesID)
        {
            IList<TempBasketDto> data = new List<TempBasketDto>();
            foreach (var item in works.TempBasketRepository.GetAll(x => x.CookiesID == CookiesID))
            {
                data.Add(mapper.Map<TempBasketDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<TempBasketDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<TempBasketDto>>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }
        public IDataResult<TempBasketDto> GetById(int Id)
        {
            var data = works.TempBasketRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<TempBasketDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<TempBasketDto>(data));
            }
            else
            {
                return new DataResult<TempBasketDto>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }
        public IResult SepetArttirEksilt(int Id, bool islem)
        {
            try
            {
                var Sepetim = works.TempBasketRepository.GetByIdFirst(x => x.Id == Id);
                if (islem)// True ise Arttırma
                {
                    Sepetim.Piece++;
                    works.TempBasketRepository.Update(Sepetim);
                    works.SaveChanges();
                    return new Result(ResultStatus.Success, "Ürün'ün Adeti Arttırılmıştır.");
                }
                else // false ise azaltma olacaktır.
                {
                    if (Sepetim.Piece > 1)// 1'dan büyük ise azaltma
                    {
                        Sepetim.Piece--;
                        works.TempBasketRepository.Update(Sepetim);
                        works.SaveChanges();
                        return new Result(ResultStatus.Success, "Ürün'ün Adeti Azaltılmıştır.");
                    }
                    else
                    {
                        return new Result(ResultStatus.Success, "Ürün'ün Adeti Azaltılamaz.");
                    }
                }
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IResult AutoBasketUpdate(AutoBasketDto data)
        {
            try
            {
                works.AutoBasketRepository.Update(mapper.Map<AutoBasket>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Güncelleme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Güncelleme Başarısız");
            }
        }
        public IDataResult<AutoBasketDto> GetByIdAuto(int Id)
        {
            var data = works.AutoBasketRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<AutoBasketDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<AutoBasketDto>(data));
            }
            else
            {
                return new DataResult<AutoBasketDto>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }
    }
}
