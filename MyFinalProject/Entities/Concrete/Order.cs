using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    
    public class Order :IEntity // IEntity implementasyonu neden yaptık? IEntity implementasyonu, bu class'ın bir veritabanı tablosu olduğunu belirtir. //IEntity neden ipmlemente edilir? IEntity implement eden class bir veritabanı tablosudur.
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
