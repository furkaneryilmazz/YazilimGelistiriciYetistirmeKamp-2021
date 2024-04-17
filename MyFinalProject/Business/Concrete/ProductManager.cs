using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilites.Business;
using Core.Utilites.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bir iş sınıfı başka bir sınıfı new lemez. Onun yerine constructor ile enjekte edilir.

        IProductDal _productDal;
        ICategoryService _categoryService;
        //ICategoryDal _categoryDal;

        ILogger _logger;
        public ProductManager(IProductDal productDal, ICategoryService categoryService) //bir entity manager kendisi hariç başka bir dal'ı enjekte edemez.
        {
            //_categoryDal = categoryDal; bu yanlış bir kullanımdır. Çünkü bir entity manager kendisi hariç başka bir dal'ı enjekte edemez.
            _categoryService = categoryService;
            _productDal = productDal;
        }

        //Eğer bir iş sınıfı başka bir sınıfı new lerse o kodda soyutlamayı doğru yapmamışızdır.
        //Bir iş sınıfı başka bir sınıfı new lemez. Onun yerine constructor ile enjekte edilir.
        //IProductDal _productDal = new EfProductDal(); //Bu şekilde yaparsak soyutlamayı bozmuş oluruz.
        //Bu şekilde yaparsak bağımlılığımızı arttırırız. Çünkü EfProductDal'a bağımlı hale geliriz. Hangi şekilde? new EfProductDal() şeklinde.
        //[LogAspect] //AOP
        //[Validate]
        //[CacheAspect]
        //[SecuredOperation("product.add,admin")]
        //[Transaction]
        //Claim
        //JWT


        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product) //void yerine IResult yaptık. Çünkü void yerine IResult yaparsak işlem sonucu ve mesajı döndürmüş oluruz.
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());

            if(result != null)
            {
                return result;
            }


            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                //business codes //iş ihtiyaçlarına uygunluk kontrolü //if bloğu içerisinde yazdık. Çünkü eğer hata varsa ekleme işlemi yapmayacak.
                _logger.Log();
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }

            _productDal.Add(product);

            return new SuccessResult("Ürün Eklendi");
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //Any: var mı yok mu onu kontrol eder. True ya da false döner.
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult(); 
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(P => P.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            //Get nerden geldi? IProductDal'dan geldi. Çünkü IProductDal'da Get metodu var.
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //neden hata aldım? Çünkü IProductDal'da GetAll metodunda parametre yok. O yüzden hata aldık.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCategoryLimitExceded() // neden IResult döndürdük? Çünkü void döndürmek yerine IResult döndürürsek işlem sonucu ve mesajı döndürmüş oluruz. //neden IDataResult değil? Çünkü IDataResult bir data döndürür. Bizim burada data döndürmemize gerek yok. Sadece işlem sonucu ve mesajı döndürmemiz yeterli.
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count > 15) // data ne ? List<Category> döndüğü için data dedik.
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }

        //[TransactionScopeAspect]
        //public IResult AddTransactionalTest(Product product) //ne yapar? //ürün eklerken hata oluşursa hiçbir işlem yapmaz. //ne zaman kullanırız? //örneğin bir banka uygulamasında para transferi yaparken, para transferi yaparken bir hata oluşursa hiçbir işlem yapmamız gerekir.
        //{
            
        //}
    }
}
