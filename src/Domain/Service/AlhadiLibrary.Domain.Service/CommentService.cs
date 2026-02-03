using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;

namespace AlhadiLibrary.Domain.Service;

public class CommentService(ICommentRepository commentRepo) : ICommentService
{
    public async Task AddAsync(CreateCommentDto dto, int userId, CancellationToken ct)
    {
        await commentRepo.AddAsync(dto, userId, ct);
    }

    public async Task<List<CommentDto>> GetApprovedByBookIdAsync(int bookId, CancellationToken ct)
    {
        return await commentRepo.GetApprovedByBookIdAsync(bookId, ct);
    }

    public async Task ApproveAsync(int commentId, CancellationToken ct)
    {
        await commentRepo.ApproveAsync(commentId, ct);
    }
}