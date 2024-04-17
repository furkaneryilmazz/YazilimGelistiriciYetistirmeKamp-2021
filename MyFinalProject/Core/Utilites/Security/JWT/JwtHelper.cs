using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilites.Security.Encryption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } // neden yapıyoruz? appsettings.json dosyasındaki verilere ulaşmak için.
        private TokenOptions _tokenOptions; // neden yapıyoruz? appsettings.json dosyasındaki TokenOptions'ı okumak için.
        private DateTime _accessTokenExpiration; // neden yapıyoruz? token'ın ne zaman expire olacağını belirlemek için. //expire ne? token'ın süresi dolduğunda geçersiz hale gelmesi.
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration; //neden yapıyoruz? appsettings.json dosyasındaki verilere ulaşmak için.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // neden yapıyoruz? appsettings.json dosyasındaki TokenOptions'ı okumak için.

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            //claim ne? JWT içinde yer alan bilgilerdir. // neden yapıyoruz? JWT içinde yer alacak olan bilgileri oluşturmak için.
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
