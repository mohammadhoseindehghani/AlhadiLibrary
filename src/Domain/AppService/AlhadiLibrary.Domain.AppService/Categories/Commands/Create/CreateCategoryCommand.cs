using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<int>
{
    public CreateCategoryDto Dto { get; set; }
}