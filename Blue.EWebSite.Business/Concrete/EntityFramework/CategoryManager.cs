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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [FluentValidationAspect(typeof(CategoryValidation))]
        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { Id = categoryId });
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
