using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }
}