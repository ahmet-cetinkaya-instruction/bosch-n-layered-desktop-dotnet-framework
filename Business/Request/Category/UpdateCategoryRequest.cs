using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request
{
    public class UpdateCategoryRequest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
