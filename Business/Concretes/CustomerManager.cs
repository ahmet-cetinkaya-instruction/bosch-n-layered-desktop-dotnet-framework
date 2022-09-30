using Business.Abstracts;
using Business.BusinessRules;
using Business.Request.Customer;
using Business.Response.Customer;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        CustomerBusinessRules _customerBusinessRules;

        public CustomerManager(ICustomerDal customerDal, CustomerBusinessRules customerBusinessRules)
        {
            _customerDal = customerDal;
            _customerBusinessRules = customerBusinessRules;
        }
        public void Add(CreateCustomerRequest customer)
        {
            _customerBusinessRules.CheckIfCustomerExist(customer.CustomerID);
            Customer newCustomer = new Customer()
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            };

            _customerDal.Add(newCustomer);
        }

        public void Delete(string id)
        {
            Customer foundCustomer = _customerDal.GetById(id);
            _customerBusinessRules.CheckIfCustomerDoesNotExist(foundCustomer);
            _customerDal.Delete(foundCustomer);
        }

        public List<ListCustomerResponse> GetAll()
        {
            List<ListCustomerResponse> customers = new List<ListCustomerResponse>();
            foreach (var customer in _customerDal.GetAll())
            {
                ListCustomerResponse listCustomerResponse = new ListCustomerResponse();
                listCustomerResponse.CustomerID = customer.CustomerID;
                listCustomerResponse.CompanyName = customer.CompanyName;
                customers.Add(listCustomerResponse);
            }

            return customers;
        }

        public GetCustomerResponse GetById(string id)
        {
            Customer customer = _customerDal.GetById(id);
            GetCustomerResponse response = new GetCustomerResponse()
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            };
            return response;
        }

        public void Update(UpdateCustomerRequest request)
        {
            Customer foundCustomer = _customerDal.GetById(request.CustomerID);
            _customerBusinessRules.CheckIfCustomerDoesNotExist(foundCustomer);
            foundCustomer.CustomerID = request.CustomerID;
            foundCustomer.CompanyName = request.CompanyName;
            foundCustomer.ContactName = request.ContactName;

            _customerDal.Update(foundCustomer);
        }
    }
}
