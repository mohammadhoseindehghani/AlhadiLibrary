using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<UpdateCategoryCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryService.UpdateAsync(request.Dto, cancellationToken);
        return Unit.Value;
    }
}