using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;

namespace AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Data;

public interface ICommentRepository
{
    Task AddAsync(CreateCommentDto dto, int userId, CancellationToken ct);
    Task<List<CommentDto>> GetApprovedByBookIdAsync(int bookId, CancellationToken ct);
    Task ApproveAsync(int commentId, CancellationToken ct);
}
