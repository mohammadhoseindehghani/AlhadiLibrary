using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Queries.GetAll;

public class GetAllCategoryQueryHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoryQuery,List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await categoryService.GetAllAsync(cancellationToken);
    }
}