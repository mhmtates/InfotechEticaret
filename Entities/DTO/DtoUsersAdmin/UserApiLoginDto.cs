using Core.Entitiess.Abstract;
namespace Entities.DTO
{
    public class UserApiLoginDto: IDTO
    {
        public string EPosta { get; set; }
        public string Password { get; set; }
    }
}
