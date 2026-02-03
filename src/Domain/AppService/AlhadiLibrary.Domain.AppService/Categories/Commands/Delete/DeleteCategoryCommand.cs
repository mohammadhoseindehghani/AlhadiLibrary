using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }
}