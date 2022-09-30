using Business.Request;
using Business.Response;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        List<ListCategoryResponse> GetAll();

        void Add(CreateCategoryRequest request);
        void Update(UpdateCategoryRequest request);
        void Delete(DeleteCategoryRequest request);

        GetCategoryResponse GetById(int id);

    }
}
