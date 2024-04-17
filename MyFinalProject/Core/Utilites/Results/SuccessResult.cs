using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class SuccessResult :Result
    {
        public SuccessResult(string message) : base(true, message)//base:Result//true:success//base(true):Result'ın constructor'ını çalıştırır.
        {

        }
        //mesaj vermek istemiyorsak bu constructor'ı kullanırız.//base:Result//true:success//base(true):Result'ın constructor'ını çalıştırır.
        public SuccessResult():base(true)
        {

        }
    }
}
