using System;
using System.Windows.Forms;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Concretes;
using Business.Profiles;
using Business.Request;
using Business.Response;
using DataAccess.Abstracts;
using DataAccess.Concretes.Adonet;
using DataAccess.Concretes.EntityFramework;

namespace WinFormsUI
{
    public partial class Form1 : Form
    {
        private ICategoryService _categoryService;
        private ICustomerService _customerService;
        public Form1()
        {
            ICategoryDal categoryDal = new EfCategoryDal();
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
            //var result = _categoryService.GetAll();
            //Console.WriteLine(result.Id + "  " + result.Name+ " " + result.Description);

            foreach (ListCategoryResponse item in _categoryService.GetAll())
                Console.WriteLine(value: "Category : " + item.Id + " " + item.Name);

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

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            _categoryService.Add(
                request: new CreateCategoryRequest { Name = "Beverages", Description = "Computer_Desc" });

            //_categoryService.Update(
            //    request: new UpdateCategoryRequest { Id = 9, Name = "Computer", Description = "Computer_Description" });

            //_categoryService.Delete(
            //    request: new DeleteCategoryRequest { Id = 16 });
        }
    }
}
