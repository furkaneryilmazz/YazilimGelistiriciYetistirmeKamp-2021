using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager //Cache ile ilgili operasyonları yapacak olan sınıf
    {
        T Get<T>(string key); //generic metot
        object Get(string key); //generic olmayan metot
        void Add(string key, object value, int duration); //duration: cache'de ne kadar süre duracak 
        bool IsAdd(string key); //cache'de var mı yok mu kontrolü
        void Remove(string key); //cache'den uçurma
        void RemoveByPattern(string pattern); //verilen pattern'a göre silme işlemi yapacak //pattern nedir? //çalışma anında bellekte oluşan bir yapıyı silmeye yarar.
    }
}
