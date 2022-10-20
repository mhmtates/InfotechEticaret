using Core.Entitiess.Abstract;

namespace Entities.Concrete
{
    public class Variants:IEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; } // Renk,Numara,Kğ. vb
        public string Name { get; set; } // Kırmızı, Mavi,Yeşil,  38,39,40
        public int ProductsId { get; set; }
        public decimal Price { get; set; }
        public virtual Products Products { get; set; }
    }
}
