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
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.FirstOrDefault(i => i.CategoryID == id);
            }
        }

        public void Delete(Category request)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                Category categoryToDelete = context.Categories.FirstOrDefault(i=>i.CategoryID == request.CategoryID);
                context.Categories.Remove(categoryToDelete);
                context.SaveChanges();
            }
        }

        public void Update(Category request)
        {
            throw new NotImplementedException();
        }

        public void Add(Category request)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                context.Categories.Add(request);
                context.SaveChanges();
            }
        }
    }
}
