﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.EWebSite.WebUI.ViewComponents
{
    public class FooterViewComponent: ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
