using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order> //IOrderDal, IEntityRepository'den miras alır. //neden bunu yaptık? IOrderDal, Order nesnesi için özelleştirilmiş operasyonları içerebilir.
    {

    }
}
