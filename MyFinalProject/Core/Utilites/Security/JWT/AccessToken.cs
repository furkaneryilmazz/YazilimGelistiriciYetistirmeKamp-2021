using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.JWT
{
    public class AccessToken // bu class ne işe yarar? JWT'nin dışarıya servis edilebilmesi için oluşturulmuş bir class'tır. // neden yapıyoruz? JWT'nin içinde token ve expiration bilgisi olacak.
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
