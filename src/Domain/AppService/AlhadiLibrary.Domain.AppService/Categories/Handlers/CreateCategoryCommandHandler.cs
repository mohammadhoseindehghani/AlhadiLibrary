using AlhadiLibrary.Domain.AppService.Categories.Commands;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Handlers;

public class CreateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryCommand,int>
{
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.CreateAsync(request.Dto, cancellationToken);
    }
}