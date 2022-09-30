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
using AutoMapper;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private CategoryBusinessRules _businessRules;
        private IMapper _mapper;
        public CategoryManager(ICategoryDal category, CategoryBusinessRules businessRules, IMapper mapper)
        {
            _categoryDal = category;
            _businessRules = businessRules;
            _mapper = mapper;
        }

        public void Add(CreateCategoryRequest request)
        {
            _businessRules.CheckIfCategoryNameExists(request.Name);
            Category category = _mapper.Map<Category>(request);
            _categoryDal.Add(category); 
        }

        public void Delete(DeleteCategoryRequest request)
        {
            _businessRules.CheckIfCategoryNotExist(request.Id);
            Category category = _mapper.Map<Category>(request);
            _categoryDal.Delete(category);
        }

        public List<ListCategoryResponse> GetAll()
        {
            List<Category> categories = _categoryDal.GetAll();
            List<ListCategoryResponse> list = _mapper.Map<List<ListCategoryResponse>>(categories);
            return list;
        }

        public GetCategoryResponse GetById(int id)
        {
            var result = _categoryDal.GetById(id);
            _businessRules.CheckIfCategoryNotExist(result);
            var response = _mapper.Map<GetCategoryResponse>(result);
            return response;
        }

        public void Update(UpdateCategoryRequest request)
        {
            _businessRules.CheckIfCategoryNotExist(request.CategoryID);
            Category entity = _mapper.Map<Category>(request);
            _categoryDal.Update(entity);
        }
    }
}
