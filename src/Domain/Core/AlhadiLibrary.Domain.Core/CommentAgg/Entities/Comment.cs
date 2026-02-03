using AlhadiLibrary.Domain.Core._common;
using AlhadiLibrary.Domain.Core.BookAgg.Entities;
using AlhadiLibrary.Domain.Core.CommentAgg.Enums;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;

namespace AlhadiLibrary.Domain.Core.CommentAgg.Entities;

public class Comment : BaseEntity
{
    public string Title { get;  set; }
    public string Text { get;  set; }
    public RateEnum Rating { get;  set; }
    public bool IsApproved { get;  set; }

    public int BookId { get;  set; }
    public Book Book { get;  set; }

    public int UserId { get;  set; }
    public User User { get;  set; }
}