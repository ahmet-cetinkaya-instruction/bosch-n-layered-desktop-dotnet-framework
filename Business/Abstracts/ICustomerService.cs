using Business.Request.Customer;
using Business.Response.Customer;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        List<ListCustomerResponse> GetAll();
        GetCustomerResponse GetById(string id);
        void Add(CreateCustomerRequest customer);
        void Update(UpdateCustomerRequest customer);
        void Delete(string id);
    }
}
