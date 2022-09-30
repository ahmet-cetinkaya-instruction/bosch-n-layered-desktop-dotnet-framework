using Core.DataAccess.Adonet.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Adonet
{
    public class AdoCategoryDal :ICategoryDal
    {
        public void Add(Category request)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category request)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            List<Category> _category = DbHelper.CreateReadConnection<Category>("select * from Categories");

            return _category;
        }

        public Category GetById(int id)
        {
            Category category = DbHelper.CreateReadConnection<Category>($"select * from Categories where CategoryId={id}").FirstOrDefault();
            return category;
        }

        public void Update(Category request)
        {
            throw new NotImplementedException();
        }
    }
}
