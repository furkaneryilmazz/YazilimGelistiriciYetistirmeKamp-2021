using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)//base:Result//false:success//base(false):Result'ın constructor'ını çalıştırır.
        {

        }
        //mesaj vermek istemiyorsak bu constructor'ı kullanırız.//base:Result//false:success//base(false):Result'ın constructor'ını çalıştırır.
        public ErrorResult() : base(false)
        {

        }
    }
}
