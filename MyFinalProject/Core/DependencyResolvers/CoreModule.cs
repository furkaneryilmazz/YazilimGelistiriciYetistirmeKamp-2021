using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilites.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection) //burdan napıyoz? bu metodu oluşturduk. //bu metodu oluşturduğumuzda bu modül yüklendiğinde bu metot çalışacak.
        {
            serviceCollection.AddMemoryCache(); //burda napıyoruz? bu metodu kullanarak servislerimize memory cache eklemiş oluyoruz.
            //burda napıyoruz? bu modül yüklendiğinde IHttpContextAccessor'ü ekliyoruz. //bu ne işe yarar? bu servislerin instance'larına erişebilmemizi sağlar. //nasıl yani? bu servislerin new'lenmiş hali diyebiliriz. //instance ne? bir class'ın bellekteki örneği. //bu ne işe yarar? bu servislerin instance'larına erişebilmemizi sağlar.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
