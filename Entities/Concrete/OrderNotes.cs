using Core.Entitiess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderNotes:IEntity
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public string Notes { get; set; }
        public DateTime NotDate { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
