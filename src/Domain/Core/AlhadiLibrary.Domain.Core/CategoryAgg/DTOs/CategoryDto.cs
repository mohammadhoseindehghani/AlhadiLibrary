namespace AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? ImagePath { get; set; }
    public bool IsActive { get; set; }

    public int? ParentId { get; set; }
    public string? ParentTitle { get; set; }
}
