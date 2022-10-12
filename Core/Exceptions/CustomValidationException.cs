using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class CustomValidationException : ValidationException
    {
        public CustomValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
        {
        }

        public override string ToString()
        {
            string message = "";
            foreach (var item in Errors)
            {
                message += item.ErrorMessage + "\n";
            }
            return message.ToString();
        }
    }
}
