using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //base:Result//success ve message'yi base'e yollar.//Data'yı da ekler.//Data'yı da ekler.
        public DataResult(T data,bool success, string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
