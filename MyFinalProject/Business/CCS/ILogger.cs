using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public interface ILogger
    {
        //burada ne yapacağız? Loglama işlemi yapacağız. Loglama işlemi yaparken ne yapacağız? Mesela bir dosyaya loglama yapabiliriz. Bir veritabanına loglama yapabiliriz. Bir sms atabiliriz. Bir mail atabiliriz. Bunları yaparken ne yapmamız gerekiyor? Bir log //Log nedir ? Loglama demektir. Loglama nedir? Bir uygulama içerisinde bir işlem yapılırken, o işlemin detaylarını kaydetmektir. Örneğin bir kullanıcı bir ürün eklediğinde, bu ürün eklenirken hangi kullanıcı tarafından eklenmiş,
        void Log();
    }
}
