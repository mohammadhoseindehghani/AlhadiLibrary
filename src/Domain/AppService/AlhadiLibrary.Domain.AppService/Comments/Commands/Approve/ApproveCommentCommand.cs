using MediatR;

namespace AlhadiLibrary.Domain.AppService.Comments.Commands.Approve;

public class ApproveCommentCommand : IRequest<Unit>
{
    public int CommentId { get; set; }
}