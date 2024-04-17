using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider(); //burada  naptık? bu servislerin provider'ını oluşturduk. //servislerin provider'ını oluşturduğumuzda artık bu servislerin instance'larına erişebiliriz. // provider ne? servislerin new'lenmiş hali.//nasıl yani? bu servislerin new'lenmiş hali diyebiliriz.//bu ne işe yarar? bu servislerin instance'larına erişebilmemizi sağlar.
            return services;
        }
    }
}
