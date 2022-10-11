using Business.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationResolvers.FluentValidation.Category
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
            RuleFor(i => i.Name).MinimumLength(3).WithMessage("Name alanı en az 3 karakter olmalıdır.");

            // Tüm descriptionlar A harfi ile başlamalı..
            RuleFor(i => i.Description).Must(StartsWithA).WithMessage("Description alanı A harfi ile başlamalıdır.");
        }

        private bool StartsWithA(string description)
        {
            return description.StartsWith("A");
        }
    }
}
