using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.Entities.Concrete;
using Blue.EWebSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blue.EWebSite.WebUI.Controllers
{

    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }

        public IActionResult Detail(int? id)
        {
            var entity = _productService.Get(c => c.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(new ProductModel { Products = entity });
        }
    }
}