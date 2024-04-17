using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //InMemoryProductDal, IProductDal interface'ini implemente ediyor.
    public class InMemoryProductDal : IProductDal
    {
        //Burada bir liste oluşturuyoruz. Bu liste Product türünde olacak.
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Ürünleri simüle ediyoruz.
            _products = new List<Product>
            {
                //Ürünlerin özelliklerini belirtiyoruz.
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            //foreach döngüsü ile listedeki ürünleri tek tek dolaşıyoruz.
            foreach(var p in _products)
            {
                if(product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }
            _products.Remove(productToDelete);

            //LINQ ile nasıl yapılır? 
            //Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            //_products.Remove(productToDelete);
            //SingleOrDefault: listede tek bir eleman bulmaya yarar. Eğer bu eleman yoksa null döner.
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
