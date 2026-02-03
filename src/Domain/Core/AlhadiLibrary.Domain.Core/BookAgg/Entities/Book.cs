using AlhadiLibrary.Domain.Core._common;
using AlhadiLibrary.Domain.Core.CategoryAgg.Entities;
using AlhadiLibrary.Domain.Core.CommentAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;

namespace AlhadiLibrary.Domain.Core.BookAgg.Entities;

public class Book : BaseEntity
{
    public string Title { get;  set; }
    public decimal Price { get;  set; }
    public int PageCount { get;  set; }
    public string ImagePath { get;  set; }

    public int CategoryId { get;  set; }
    public Category Category { get;  set; }

    public ICollection<BookAuthor> Authors { get;  set; }
    public ICollection<BookTranslator> Translators { get;  set; }
    public ICollection<Comment> Comments { get;  set; }
}
