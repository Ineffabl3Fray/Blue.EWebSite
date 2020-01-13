using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.Business.ValidationRules.FluentValidation;
using Blue.EWebSite.Core.Aspects.PostSharp.ValidationAspects;
using Blue.EWebSite.DataAccess.Abstract;
using Blue.EWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blue.EWebSite.Business.Concrete.EntityFramework
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        [FluentValidationAspect(typeof(ProductValidation))]
        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { Id = productId });
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetAll(c => c.CategoryId == categoryId || categoryId == 0);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
