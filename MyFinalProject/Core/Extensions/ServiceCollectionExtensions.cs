using Core.Utilites.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions //neden static? çünkü bu bir extension method. //bu ne işe yarar? bu class'ı static yaparak bu class'ın instance'ını oluşturmadan bu class'ın metodlarını kullanabiliriz.
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) //this nedir? bu ne işe yarar? bu bir extension method. //bu ne işe yarar? bu metodu IServiceCollection'a eklememizi sağlar. //bu metot ne işe yarar? bu metot bütün servis bağımlılıklarını yüklememizi sağlar. //bu metot ne alır? bu metot ICoreModule[] modules alır. //ICoreModule[] modules ne işe yarar? bu modüllerin yüklenmesini sağlar. //this? bu metotun bir extension method olduğunu belirtir. //IServiceCollection ne işe yarar? bu servislerin bağımlılıklarını yüklememizi sağlar.
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection); //bu satırda ne yaptık? bu servislerin provider'ını oluşturduk. //bu ne işe yarar? bu servislerin instance'larına erişebilmemizi sağlar.
        }
    }
}
