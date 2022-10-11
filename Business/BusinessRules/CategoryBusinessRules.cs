using Core.Exceptions;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CategoryBusinessRules
    {
        private ICategoryDal _category;
        public CategoryBusinessRules(ICategoryDal category)
        {
            _category = category;
        }

        public void CheckIfCategoryNotExist(int id)
        {
            var result = _category.GetById(id);
            CheckIfCategoryNotExist(result);
        }
        public void CheckIfCategoryNameExists(string name)
        {
            var result = _category.GetAll().FirstOrDefault(c=>c.CategoryName==name);
            CheckIfCategoryExists(result);

        }
        public void CheckIfCategoryExists(int id)
        {
            var result = _category.GetById(id);
            CheckIfCategoryExists(result);

        }

        public void CheckIfCategoryNotExist(Category category)
        {

            if (category is null)
                throw new BusinessException("Bu category'nin kaydı bulunmamaktadır.");
        }
        public void CheckIfCategoryExists(Category category)
        {
            if (category != null)
                throw new BusinessException("Bu category'nin kaydı bulunmaktadır.");

        }


    }
}
