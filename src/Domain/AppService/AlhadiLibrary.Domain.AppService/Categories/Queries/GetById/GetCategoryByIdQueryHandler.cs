using AlhadiLibrary.Domain.AppService.Books.Queries;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Queries.GetById;

public class GetCategoryByIdQueryHandler(ICategoryService categoryService) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await categoryService.GetByIdAsync(request.Id, cancellationToken);
    }
}