using Blue.EWebSite.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.Business.ValidationRules.FluentValidation
{
    public class ProductValidation: AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(c => c.Description).NotEmpty().Length(10,250);
            RuleFor(c => c.InStock).NotEmpty();
            RuleFor(c => c.Name).NotEmpty().Length(2,50);
            RuleFor(c => c.StockQuantity).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(c => c.UnitPrice).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
