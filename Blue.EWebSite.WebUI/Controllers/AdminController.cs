using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.Entities.Concrete;
using Blue.EWebSite.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blue.EWebSite.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var model = new ProductModel
            {
                Products = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Insert(ProductModel model)
        {
            var product = new Product
            {
                Name = model.Products.Name,
                Description = model.Products.Description,
                CategoryId = model.Products.CategoryId,
                InStock = model.Products.InStock,
                StockQuantity = model.Products.StockQuantity,
                UnitPrice = model.Products.UnitPrice
            };
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index", "Admin");
            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            var entity = _productService.Get(c => c.Id == id);
            var model = new ProductModel()
            {
                Products = entity,
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.Get(c => c.Id == model.Products.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Products.Name;
                entity.Description = model.Products.Description;
                entity.CategoryId = model.Products.CategoryId;
                entity.InStock = model.Products.InStock;
                entity.UnitPrice = model.Products.UnitPrice;
                entity.StockQuantity = model.Products.StockQuantity;

                _productService.Update(entity);
                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            var model = _productService.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            _productService.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}