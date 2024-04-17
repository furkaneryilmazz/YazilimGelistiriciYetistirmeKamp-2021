using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.Encryption
{
    public class SecurityKeyHelper // ne yapacağız? SecurityKey oluşturacağız. // o nedir ? JWT için oluşturacağımız bir anahtardır.
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
