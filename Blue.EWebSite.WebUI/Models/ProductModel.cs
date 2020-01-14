using Blue.EWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.EWebSite.WebUI.Models
{
    public class ProductModel
    {
        public Product Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
