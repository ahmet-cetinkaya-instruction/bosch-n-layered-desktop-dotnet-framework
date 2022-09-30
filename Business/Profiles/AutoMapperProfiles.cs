using System.Collections.Generic;
using AutoMapper;
using Business.Request;
using Business.Response;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, GetCategoryResponse>()
                .ForMember(c => c.Id,
                           config => config.MapFrom(c => c.CategoryID))
                .ForMember(c => c.Name,
                           config => config.MapFrom(c => c.CategoryName));
            CreateMap<List<Category>, List<ListCategoryResponse>>();
        }
    }
}