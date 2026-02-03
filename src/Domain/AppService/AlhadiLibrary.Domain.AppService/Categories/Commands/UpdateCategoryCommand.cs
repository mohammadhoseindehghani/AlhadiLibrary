using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public UpdateCategoryDto Dto { get; set; }
}