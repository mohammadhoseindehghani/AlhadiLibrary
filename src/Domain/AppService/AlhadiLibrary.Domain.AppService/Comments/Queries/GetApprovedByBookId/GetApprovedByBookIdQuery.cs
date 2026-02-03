using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Comments.Queries.GetApprovedByBookId;

public class GetApprovedByBookIdQuery : IRequest<List<CommentDto>>
{
    public int BookId { get; set; }
}