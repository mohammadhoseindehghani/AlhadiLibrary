using AlhadiLibrary.Domain.Core.CommentAgg.Enums;

namespace AlhadiLibrary.Domain.Core.CommentAgg.DTOs;

public class CommentDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public RateEnum Rating { get; set; }
    public string UserFullName { get; set; }
    public DateTime CreatedAt { get; set; }
}