
using AlhadiLibrary.Domain.Core._common;
using AlhadiLibrary.Domain.Core.BookAgg.Entities;

namespace AlhadiLibrary.Domain.Core.UserAgg.Entities;

public class BookAuthor : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int AuthorId { get; set; }
    public User Author { get; set; }
}


