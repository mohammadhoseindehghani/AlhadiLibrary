using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Comments.Commands.Approve;

public class ApproveCommentCommandHandler(ICommentService commentService) : IRequestHandler<ApproveCommentCommand, Unit>
{
    public async Task<Unit> Handle(ApproveCommentCommand request, CancellationToken cancellationToken)
    {
        await commentService.ApproveAsync(request.CommentId, cancellationToken);
        return Unit.Value;
    }
}