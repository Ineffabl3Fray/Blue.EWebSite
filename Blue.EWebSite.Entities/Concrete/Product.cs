using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.Entities.Concrete
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
