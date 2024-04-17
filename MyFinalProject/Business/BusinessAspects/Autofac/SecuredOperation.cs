using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilites.Interceptors;
using Core.Utilites.IoC;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    //JWT için bu class'ı oluşturduk.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //her istek için bir httpcontext oluşturur.net core'un bir servisidir. 

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //rolleri virgülle ayırıp array'e atıyoruz.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //burada napıyoz? Kullanıcının rollerini alıyoruz.// nasıl yani? ClaimRoles'u extension method olarak yazdık.//burada ne yapıyoruz? Kullanıcının rolleri ile attribute'deki rolleri karşılaştırıyoruz.
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role)) //burada ne yapıyoruz? Eğer rollerimizden biri claimlerimizde varsa işlemi gerçekleştirir.
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
