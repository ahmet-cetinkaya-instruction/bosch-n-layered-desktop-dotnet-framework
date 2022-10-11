using System;
using System.Collections.Generic;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Request;
using Business.Response;
using Business.ValidationResolvers.FluentValidation.Category;
using DataAccess.Abstracts;
using Entities.Concretes;
using FluentValidation;

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
            //_businessRules.CheckIfCategoryNameExists(request.Name);
            //System.ComponentModel.DataAnnotations.ValidationContext context = new System.ComponentModel.DataAnnotations.ValidationContext(request, null, null);

            //IList<ValidationResult> validationResults = new List<ValidationResult>();

            //if (!Validator.TryValidateObject(request, context, validationResults,true))
            //{
            //    foreach (var result in validationResults)
            //    {
            //        Console.WriteLine("Validasyon Hatası:" + result.ErrorMessage);
            //    }

            //    return;
            //}

            var context = new ValidationContext<CreateCategoryRequest>(request);
            IValidator validator = new CreateCategoryRequestValidator();

            var result = validator.Validate(context);

            if (!result.IsValid) // Validasyon hatası mevcut!!
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }

                //TO DO: Throw exception and handle globally.

                return;
            }


            //ValidationTool.Validate(validator, request);
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
            _businessRules.CheckIfCategoryNotExist(request.Id);
            Category entity = _mapper.Map<Category>(request);
            _categoryDal.Update(entity);
        }
    }
}
