using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorMessage { get; set; }
        public BusinessException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
