using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using AlhadiLibrary.Domain.Core.CategoryAgg.Entities;
using AutoMapper;

namespace AlhadiLibrary.DataAccess.Repo.EfCore.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
   
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ParentTitle,
                opt => opt.MapFrom(src =>
                    src.Parent != null ? src.Parent.Title : null));
    }
}