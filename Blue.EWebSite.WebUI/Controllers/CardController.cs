using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.WebUI.ExtensionMethods;
using Blue.EWebSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blue.EWebSite.WebUI.Controllers
{
    public class CardController : Controller
    {
        private IProductService _productService;

        public CardController(IProductService productService)
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

        public IActionResult AddToCard(int id)
        {
            var product = _productService.Get(c => c.Id == id);
            if (product != null)
            {
                List<CardViewModel> cart = new List<CardViewModel>();
                cart.Add(new CardViewModel
                {
                    Product = product,
                });
                HttpContext.Session.SetObject("product", cart);
            }
            return RedirectToAction("Index");
        }

    }
}