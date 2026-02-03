using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Comments.Queries.GetApprovedByBookId;

public class GetApprovedByBookIdCommandHandler(ICommentService commentService) : IRequestHandler<GetApprovedByBookIdQuery, List<CommentDto>>
{
    public Task<List<CommentDto>> Handle(GetApprovedByBookIdQuery request, CancellationToken cancellationToken)
    {
        return commentService.GetApprovedByBookIdAsync(request.BookId, cancellationToken);
    }
}