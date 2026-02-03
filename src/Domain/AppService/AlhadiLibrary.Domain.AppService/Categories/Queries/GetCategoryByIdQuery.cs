using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; set; }
}