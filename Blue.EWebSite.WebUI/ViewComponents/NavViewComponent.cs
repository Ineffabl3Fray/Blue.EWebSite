using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.EWebSite.WebUI.ViewComponents
{
    public class NavViewComponent: ViewComponent
    {
        private ICategoryService _categoryService;

        public NavViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            return View(new CategoryListModel
            {
                Categories = _categoryService.GetAll()
            });
        }
    }
}
