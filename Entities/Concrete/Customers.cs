using Core.Entitiess.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Customers: IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }// NameSurname  Like '%Ahmet%'
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; } // Şehir
        public string District { get; set; } // ilçe
        public string FullAddress { get; set; } // ilçe
        public string Password { get; set; }
        public bool Advert { get; set; } // Mail ve SMS olarak Bilgilendirme izni.
        public bool Gender { get; set; } // Erkek(10) ve Kadın(10) => Bit 2 Byte True False
        public ICollection<Orders> Orders { get; set; }
    }
}
