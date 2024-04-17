using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)//this(success) sayesinde tek parametreli constructor'ı da çalıştırır.
        {
            //get; private set; sayesinde sadece okunabilir. Yani sadece constructor'da set edilebilir.
            Message = message;
        }
        //Overloading //Mesaj vermek istemiyorsak bu constructor'ı kullanırız.
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
