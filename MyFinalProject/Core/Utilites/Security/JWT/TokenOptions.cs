using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.JWT
{
    public class TokenOptions
    {
        //burada ne yapıyoruz? JWT'nin ayarlarını tutacağımız bir class oluşturuyoruz.
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
