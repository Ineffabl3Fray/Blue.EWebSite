using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.Entities.Concrete
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
