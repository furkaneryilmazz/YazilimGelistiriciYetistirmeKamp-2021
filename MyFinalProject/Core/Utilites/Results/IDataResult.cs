using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public interface IDataResult<T>:IResult //IResult'dan implemente edildi.//T:generic//T tipinde bir data olacak.//IResult'daki Success ve Message'ye ek olarak Data'yı da içerir.
    {
        T Data { get; }

    }
}
