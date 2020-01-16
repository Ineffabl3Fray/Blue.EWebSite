using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.Entities.Concrete;
using Blue.EWebSite.WebUI.ExtensionMethods;
using Blue.EWebSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.EWebSite.WebUI.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public NavViewComponent(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public ViewViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.GetObject<List<CardViewModel>>("product");
            if (cart != null)
            {
                var product = cart.Select(c => c.Product).FirstOrDefault();

                return View(new CardViewModel
                {
                    Categories = _categoryService.GetAll()
                });
            }
            return View(new CardViewModel
            {
                Categories = _categoryService.GetAll()
            });
        }

    }
}

