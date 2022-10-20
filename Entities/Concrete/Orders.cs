using Core.Entitiess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Orders:IEntity
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CargoNumber { get; set; }
        public string OdemeTuru { get; set; }
        public decimal CargoPrice { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public byte Kdv { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal CouponPrice { get; set; }
        public  ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<OrderNotes> OrderNotes { get; set; }
        public ICollection<OrderInformations> OrderInformations { get; set; }
        public virtual  Customers Customers { get; set; }
    }
}
