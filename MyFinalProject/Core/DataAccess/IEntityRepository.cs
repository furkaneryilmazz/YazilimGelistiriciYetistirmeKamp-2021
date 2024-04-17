using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess
{
    //generic constraint
    //class: referans tip olabilir demek
    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new() //T bir referans tip olmalı ve IEntity den implemente edilmeli.
    {
        //ne yaptık burada? T tipinde bir nesne ver. Bu nesne bir referans tip olmalı ve IEntityRepository den implemente edilmeli.
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        //filter=null filtre vermeyedebilirsin demek. //GetAll() dediğimizde tüm datayı getirir. GetAll(p=>p.CategoryId==2) dediğimizde sadece CategoryId si 2 olanları getirir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
