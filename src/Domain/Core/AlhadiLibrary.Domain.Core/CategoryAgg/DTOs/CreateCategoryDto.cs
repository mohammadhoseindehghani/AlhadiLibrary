using MediatR;

namespace AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;

public class CreateCategoryDto
{
    public string Title { get; set; }
    public string? ImagePath { get; set; }
    public bool IsActive { get; set; }

    public int? ParentId { get; set; }
}
