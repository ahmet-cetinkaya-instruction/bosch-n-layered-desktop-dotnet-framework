using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public List<Category> GetAll()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category request)
        {
            throw new NotImplementedException();
        }

        public void Update(Category request)
        {
            throw new NotImplementedException();
        }

        public void Add(Category request)
        {
            throw new NotImplementedException();
        }
    }
}
