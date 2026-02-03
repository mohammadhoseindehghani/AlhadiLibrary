using AlhadiLibrary.Domain.Core.CommentAgg.Enums;

namespace AlhadiLibrary.Domain.Core.CommentAgg.DTOs;

public class CreateCommentDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public RateEnum Rating { get; set; }
}