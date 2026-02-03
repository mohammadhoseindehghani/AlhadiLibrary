using AlhadiLibrary.Domain.AppService.Categories.Commands;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Handlers;

public class UpdateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<UpdateCategoryCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryService.UpdateAsync(request.Dto, cancellationToken);
        return Unit.Value;
    }
}