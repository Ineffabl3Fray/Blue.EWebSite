using Blue.EWebSite.Core.Concrete;
using Blue.EWebSite.DataAccess.Abstract;
using Blue.EWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.DataAccess.Concrete.EntityFramework
{
    public class ProductDal : RepositoyBase<Product, BlueContext>, IProductDal
    {
    }
}
