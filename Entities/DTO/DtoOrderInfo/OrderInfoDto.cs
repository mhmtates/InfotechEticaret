using Core.Entitiess.Abstract;
using System;

namespace Entities.DTO
{
	public class OrderInfoDto : IDTO
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public bool Sms { get; set; }
        public bool Email { get; set; }
        public string Message { get; set; }
        public DateTime InfoDate { get; set; }
        public int OrdersId { get; set; }
    }
}
