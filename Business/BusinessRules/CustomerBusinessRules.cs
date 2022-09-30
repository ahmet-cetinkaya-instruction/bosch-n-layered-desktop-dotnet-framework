using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CustomerBusinessRules
    {
        ICustomerDal _customerDal;
        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void CheckIfCustomerExist(string id)
        {
            Customer customer = _customerDal.GetById(id);
            CheckIfCustomerExist(customer);
        }

        public void CheckIfCustomerExist(Customer customer)
        {
            if (customer != null)
                throw new Exception("böyle bir müşteri zaten mevcut!");
        }

        public void CheckIfCustomerDoesNotExist(string id)
        {
            Customer customer = _customerDal.GetById(id);
            CheckIfCustomerDoesNotExist(customer);
        }

        public void CheckIfCustomerDoesNotExist(Customer customer)
        {
            if (customer == null)
                throw new Exception("Müşteri bulunamadı.");
        }
    }
}
