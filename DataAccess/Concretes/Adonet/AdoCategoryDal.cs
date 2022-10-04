using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Adonet.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.Adonet
{
    public class AdoCategoryDal :ICategoryDal
    {
        public void Add(Category category)
        {
            int affectedRowCount = DbHelper.CreateWriteConnection(
                query: "Insert into Categories(CategoryName,Description) values(@CategoryName,@Description)",
                category
            );
            if (affectedRowCount == 0) throw new Exception(message: "No affected row.");
        }

        public void Delete(Category category)
        {
            int affectedRowCount = DbHelper.CreateWriteConnection(
                query: "Delete From Categories where CategoryID=@CategoryID",
                category
            );
            if (affectedRowCount == 0) throw new Exception(message: "No affected row.");
        }

        public List<Category> GetAll()
        {
            List<Category> _category = DbHelper.CreateReadConnection<Category>("select * from Categories");
            return _category;
        }

        public Category GetById(int id)
        {
            Category category = DbHelper
                                .CreateReadConnection<Category>(
                                    query: $"select * from Categories where CategoryID={id}").FirstOrDefault();
            return category;
        }

        public void Update(Category category)
        {
            int affectedRowCount = DbHelper.CreateWriteConnection(
                query:
                "Update Categories set CategoryName=@CategoryName, Description=@Description where CategoryID=@CategoryID",
                category
            );
            if (affectedRowCount == 0) throw new Exception(message: "No affected row.");
        }
    }
}
