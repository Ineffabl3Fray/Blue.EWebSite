using Blue.EWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blue.EWebSite.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        Product Get(Expression<Func<Product, bool>> filter);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(int productId);
    }
}
