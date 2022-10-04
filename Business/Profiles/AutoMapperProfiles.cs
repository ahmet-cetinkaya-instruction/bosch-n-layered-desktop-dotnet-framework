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
            CreateMap<CreateCategoryRequest, Category>()
                .ForMember(c => c.CategoryName, config => config.MapFrom(r => r.Name));
            CreateMap<UpdateCategoryRequest, Category>()
                .ForMember(c => c.CategoryID, config => config.MapFrom(r => r.Id))
                .ForMember(c => c.CategoryName, config => config.MapFrom(r => r.Name));
            CreateMap<Category, GetCategoryResponse>()
                .ForMember(c => c.Id,
                           config => config.MapFrom(c => c.CategoryID))
                .ForMember(c => c.Name,
                           config => config.MapFrom(c => c.CategoryName));
            CreateMap<Category, ListCategoryResponse>()
                .ForMember(r => r.Id, config => config.MapFrom(c => c.CategoryID))
                .ForMember(r => r.Name, config => config.MapFrom(c => c.CategoryName));
        }
    }
}