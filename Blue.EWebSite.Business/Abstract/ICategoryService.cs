using Blue.EWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blue.EWebSite.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category Get(Expression<Func<Category, bool>> filter);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(int categoryId);
    }
}
