using Core.Entitiess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class PImagesDto:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductsId { get; set; }
    }
}
