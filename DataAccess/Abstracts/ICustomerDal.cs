using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICustomerDal
    {
        List<Customer> GetAll();
        Customer GetById(string id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
