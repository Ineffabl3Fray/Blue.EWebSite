using Blue.EWebSite.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.Business.ValidationRules.FluentValidation
{
public    class CategoryValidation: AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name).Length(3, 50).NotEmpty();
        }
    }
}
