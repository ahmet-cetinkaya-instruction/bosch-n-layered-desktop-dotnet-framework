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
        private ListCategoryResponse selectedCategory;
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
            readData();

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
            //_categoryService.Add(
            //    request: new CreateCategoryRequest { Name = "Beveragesxx", Description = "Computer_Desc" });

            //_categoryService.Update(
            //    request: new UpdateCategoryRequest { Id = 9, Name = "Computer", Description = "Computer_Description" });

            //_categoryService.Delete(
            //    request: new DeleteCategoryRequest { Id = 16 });

            CreateCategoryRequest createCategoryRequest = new CreateCategoryRequest()
            {
                Name = categoryNameTextBox.Text,
                Description = descriptionRichTb.Text
            };

            _categoryService.Add(createCategoryRequest);
            MessageBox.Show("Kategori başarıyla eklendi","Başarılı İşlem");
            clearAddCategoryForm();
            readData();
        }

        private void clearAddCategoryForm()
        {
            categoryNameTextBox.Text = String.Empty;
            descriptionRichTb.Text = String.Empty;
        }
        private void readData()
        {
            categoriesListBox.ValueMember = "Id";
            categoriesListBox.DisplayMember = "Name";
            categoriesListBox.Items.Clear();
            foreach (ListCategoryResponse item in _categoryService.GetAll())
            {
                categoriesListBox.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readData();
        }

        private void categoriesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedCategory = (ListCategoryResponse)categoriesListBox.SelectedItem;
            updateDeleteBtnStatus();
        }

        private void updateDeleteBtnStatus()
        {
            deleteBtn.Enabled = selectedCategory != null;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(selectedCategory != null)
            {
                DeleteCategoryRequest deleteCategoryRequest = new DeleteCategoryRequest()
                {
                    Id = selectedCategory.Id
                };
                _categoryService.Delete(deleteCategoryRequest);
                selectedCategory = null;
                readData();
                updateDeleteBtnStatus();
            }
        }
    }
}
