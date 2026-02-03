using AlhadiLibrary.Domain.AppService.Categories.Commands;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Handlers;

public class DeleteCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryService.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}