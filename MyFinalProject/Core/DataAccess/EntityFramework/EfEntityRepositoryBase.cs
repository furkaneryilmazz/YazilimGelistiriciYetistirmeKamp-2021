using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    //Bu class bir repositorydir. Bu class'ın amacı bir tablo ile ilgili CRUD işlemlerini yapmaktır.
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new() //****Evet, doğru söylüyorsunuz. Interfaceler nesne olarak oluşturulamazlar, çünkü soyutlama sağlarlar ve bir arayüz olarak davranırlar. Bu yüzden new() kısıtıyla bir interface belirtilmez. İlgili kod parçasında new() kısıtı, TEntity tipinin IEntity arayüzünü uygulamak zorunda olduğunu ve ayrıca parametresiz bir kurucuya sahip olması gerektiğini belirtmek için kullanılmış gibi gözüküyor. Ancak bu kısıt, IEntity arayüzünün kendisine değil, TEntity tipine uygulanmıştır. Bu nedenle IEntity'nin kendisine uygulanan bir new() kısıtı değil, TEntity tipine uygulanan bir kısıttır. Yani, new() kısıtı IEntity arayüzüne uygulanmamıştır ve kullanılan new() kısıtı sadece TEntity tipinin nesne olarak oluşturulabilmesini sağlar. Bu, TEntity tipinin somut bir sınıf olması ve parametresiz bir kurucuya sahip olması gerektiği anlamına gelir. Bu, genellikle ORM (Object-Relational Mapping) araçları gibi veritabanı işlemleri için kullanılan generic sınıflar için yaygın bir gereksinimdir.*****
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedentity = context.Entry(entity); //referansı yakala // Entry nedir? EntityFrameworkte bir nesnenin referansını verir.
                addedentity.State = EntityState.Added; //ekleme işlemi
                context.SaveChanges(); //değişiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                //referansı yakala // Entry nedir? EntityFrameworkte bir nesnenin referansını verir.
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //Get metodu, filtre verilmezse tüm veriyi getirir.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // Singleordefault metodu bir collection içinde belirtilen koşula uyan tek bir öğeyi döndürür. 
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                //referansı yakala // Entry nedir? EntityFrameworkte bir nesnenin referansını verir.
                var updatedEntity = context.Entry(entity); // bu kod ne yapıyor? Gönderdiğim ürün id'sine karşılık gelen veritabanındaki ürünü bul.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
