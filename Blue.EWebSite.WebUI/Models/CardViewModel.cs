using Blue.EWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.EWebSite.WebUI.Models
{
    public class CardViewModel
    {
        public List<Card> Cards { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public List<Category> Categories { get; set; }
    }
}
