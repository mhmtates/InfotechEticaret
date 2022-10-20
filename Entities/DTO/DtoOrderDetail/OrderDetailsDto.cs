using Core.Entitiess.Abstract;

namespace Entities.DTO
{
	public class OrderDetailsDto : IDTO
    {
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public string VName { get; set; }
        public int OrdersId { get; set; }
    }
}
