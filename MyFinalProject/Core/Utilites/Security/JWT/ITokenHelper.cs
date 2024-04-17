using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.JWT
{
    public interface ITokenHelper // bu interface ne yapar? JWT ile ilgili operasyonları gerçekleştirecek olan sınıfların implement etmesi gereken bir interface'dir. // neden yapıyoruz? JWT ile ilgili operasyonları tek bir yerden yönetmek için.
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
