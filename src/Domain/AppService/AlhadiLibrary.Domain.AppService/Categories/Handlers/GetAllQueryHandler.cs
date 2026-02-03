using AlhadiLibrary.Domain.AppService.Categories.Queries;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Handlers;

public class GetAllQueryHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoryQuery,List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await categoryService.GetAllAsync(cancellationToken);
    }
}