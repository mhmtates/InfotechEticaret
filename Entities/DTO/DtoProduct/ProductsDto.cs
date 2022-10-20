using Core.Entitiess.Abstract;

namespace Entities.DTO
{
	public class ProductsDto: IDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public string MainImages { get; set; }
	}
}
