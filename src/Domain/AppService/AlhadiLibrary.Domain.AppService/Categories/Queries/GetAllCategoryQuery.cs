using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Queries;

public class GetAllCategoryQuery : IRequest<List<CategoryDto>>
{
    
}