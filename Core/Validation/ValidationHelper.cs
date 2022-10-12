using Core.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validation
{
    public static class ValidationHelper<T>
    {
        // Backlog: Requesti direkt validatorden alabiliriz.
        public static void Validate(Type validatorType, T request)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Provided type is not a valid validator.");
            }
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var context = new ValidationContext<T>(request);
            var result = validator.Validate(context);

            if (!result.IsValid) // Validasyon hatası mevcut!!
            {
                throw new CustomValidationException(result.Errors);
            }
        }
    }
}
