using Core.Results.Abstract;
using Entities.DTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<IList<CustomersDto>> GetAll();
        IDataResult<CustomersUpdateDto> GetById(int Id);
        IDataResult<CustomersDto> Login(string Eposta,string Telefon,string Sifre);
        IResult Add(CustomersUpdateDto data);
        IResult Update(CustomersUpdateDto data);
        IResult Delete(int Id);
    }
}
