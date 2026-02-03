using AlhadiLibrary.Db.SqlServer.EfCore.DbContext;
using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using AlhadiLibrary.Domain.Core.CommentAgg.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AlhadiLibrary.DataAccess.Repo.EfCore;

public class CommentRepository(AppDbContext context, IMapper mapper) : ICommentRepository
{
    public async Task AddAsync(CreateCommentDto dto, int userId, CancellationToken ct)
    {
        var comment = mapper.Map<Comment>(dto);
        comment.UserId = userId;

        context.Comments.Add(comment);
        await context.SaveChangesAsync(ct);
    }


    public async Task<List<CommentDto>> GetApprovedByBookIdAsync(
        int bookId,
        CancellationToken ct)
    {
        return await context.Comments
            .AsNoTracking()
            .Where(x => x.BookId == bookId && x.IsApproved)
            .ProjectTo<CommentDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }


    public async Task ApproveAsync(int commentId, CancellationToken ct)
    {
        var comment = await context.Comments
            .FirstAsync(x => x.Id == commentId, ct);

        comment.IsApproved = true;
        await context.SaveChangesAsync(ct);
    }
}