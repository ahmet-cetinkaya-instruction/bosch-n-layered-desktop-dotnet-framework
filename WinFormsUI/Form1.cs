using Business.Abstracts;
using Business.BusinessRules;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.Adonet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Business.Profiles;

namespace WinFormsUI
{
    public partial class Form1 : Form
    {
        private ICategoryService _categoryService;
        private ICustomerService _customerService;
        public Form1()
        {
            ICategoryDal categoryDal = new AdoCategoryDal();
            ICustomerDal customerDal = new AdoCustomerDal();
            AutoMapperProfiles autoMapperProfiles = new AutoMapperProfiles();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(autoMapperProfiles);
            });
            IMapper mapper = new Mapper(mapperConfig);
            _categoryService = new CategoryManager(categoryDal, new CategoryBusinessRules(categoryDal), mapper);
            _customerService = new CustomerManager(customerDal, new CustomerBusinessRules(customerDal));
            InitializeComponent();
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {

            var result = _categoryService.GetById(2);
            Console.WriteLine(result.Id + "  " + result.Name);

            //foreach (var item in _customerService.GetAll())
            //{
            //    Console.WriteLine("Customer : " + item.CustomerID + " " + item.CompanyName);
            //}

            //var resultOfCustomer = _customerService.GetById("BERGS");
            //Console.WriteLine(resultOfCustomer.CustomerID + " " + resultOfCustomer.CompanyName);

            //foreach (var item in _categoryService.GetAll())
            //{
            //    Console.WriteLine("Category : " + item.Id + " " + item.Name);
            //}


            //AdoProductDal productDal = new AdoProductDal();
            //AdoCategoryDal categoryDal = new AdoCategoryDal();
            //AdoCustomerDal customerDal = new AdoCustomerDal();
            //AdoEmployeeDal employeeDal = new AdoEmployeeDal();

            //foreach (var item in productDal.GetAll())
            //{
            //    Console.WriteLine("Product : " + item.ProductId + " " + item.ProductName);
            //}

            //foreach (var item in customerDal.GetAll())
            //{
            //    Console.WriteLine("Customer : " + item.CustomerID + " " + item.ContactName);
            //}
            //foreach (var item in employeeDal.GetAll())
            //{
            //    Console.WriteLine("Employee : " + item.EmployeeID + " " + item.FirstName);
            //}
        }
    }
}
