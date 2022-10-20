using Core.Entitiess.Abstract;
using System.Collections.Generic;


namespace Entities.Concrete
{
    // Ientity => Bu interface'yi alan sınıflar kesinlikle Veritabanı Dosyalarıdır diyoruz.
    public class Categories:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public bool Status { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
