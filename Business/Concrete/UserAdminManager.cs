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
    public class UserAdminManager : IUsersAdminService
    {
        // Readonyl Olarak Değişken tanımlandıysa, O değişkene sadece Yapıcı metot yardımıyla veri atılır.
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;

        public UserAdminManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }

        public IResult Add(UsersAdminDto data)
        {
            try
            {
                works.UsersAdminRepository.Add(mapper.Map<UsersAdmin>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı.");
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
                works.UsersAdminRepository.Delete(works.UsersAdminRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }

        public IDataResult<IList<UsersAdminDto>> GetAll()
        {
            IList<UsersAdminDto> data = new List<UsersAdminDto>();
            foreach (var item in works.UsersAdminRepository.GetAll())
            {
                data.Add(mapper.Map<UsersAdminDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<UsersAdminDto>>(ResultStatus.Success, data.Count + " Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<UsersAdminDto>>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }

        public IDataResult<UsersAdminDto> GetById(int Id)
        {
            var data = works.UsersAdminRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<UsersAdminDto>(data));
            }
            else
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }

        public IDataResult<UsersAdminDto> Login(string Email, string Password)
        {
            var data = works.UsersAdminRepository.GetByIdFirst(x => x.EPosta == Email && x.Password == Password);
            if (data != null)
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Success, "", mapper.Map<UsersAdminDto>(data));
            }
            else
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }
        public IResult Update(UsersAdminDto data)
        {
            try
            {
                works.UsersAdminRepository.Update(mapper.Map<UsersAdmin>(data));
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
