using Business.Abstracts;
using Business.BusinessRules;
using Business.Request;
using Business.Response;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private CategoryBusinessRules _businesRules;
        public CategoryManager(ICategoryDal category, CategoryBusinessRules businesRules)
        {
            _categoryDal = category;
            _businesRules = businesRules;
        }
        public void Add(CreateCategoryRequest request)
        {
            _businesRules.CheckIfCategoryNameExists(request.Name);
            Category category = new Category() { CategoryName=request.Name};
            _categoryDal.Add(category); 
        }

        public void Delete(DeleteCategoryRequest request)
        {
            _businesRules.CheckIfCategoryNotExist(request.Id);
            Category category = new Category() { CategoryID = request.Id };
            _categoryDal.Delete(category);
        }

        public List<ListCategoryResponse> GetAll()
        {
            List <ListCategoryResponse> list = new List<ListCategoryResponse> ();
            foreach (var item in _categoryDal.GetAll())
            {
                list.Add(new ListCategoryResponse() { Id = item.CategoryID, Name = item.CategoryName });
            }
            return list;
        }

        public GetCategoryResponse GetById(int id)
        {
            var result = _categoryDal.GetById(id);
            _businesRules.CheckIfCategoryNotExist(result);
            var response = new GetCategoryResponse() { Id=result.CategoryID,Name=result.CategoryName};
            return response;
        }

        public void Update(UpdateCategoryRequest request)
        {
            _businesRules.CheckIfCategoryNotExist(request.CategoryID);
            Category entity = new Category() { CategoryID=request.CategoryID ,CategoryName=request.CategoryName};
            _categoryDal.Update(entity);

        }
    }
}
