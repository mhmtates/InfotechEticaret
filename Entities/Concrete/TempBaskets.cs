using Core.Entitiess.Abstract;

namespace Entities.Concrete
{
    public class TempBaskets :IEntity
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public int CookiesID { get; set; }
        public string MainImages { get; set; }
        public string Name { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public string VName { get; set; }
        public int CustomersId { get; set; }
    }
}
