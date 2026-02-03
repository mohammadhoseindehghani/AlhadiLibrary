using AlhadiLibrary.Domain.Core._common;

namespace AlhadiLibrary.Domain.Core.CategoryAgg.Entities;

public class Category : BaseEntity
{
    public string Title { get;  set; }
    public string? ImagePath { get;  set; }
    public bool IsActive { get;  set; }

    public int? ParentId { get;  set; }
    public Category? Parent { get;  set; }

    public ICollection<Category> SubCategories { get;  set; }
}
