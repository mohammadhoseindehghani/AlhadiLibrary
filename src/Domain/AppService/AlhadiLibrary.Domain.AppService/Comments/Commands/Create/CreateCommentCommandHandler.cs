using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Comments.Commands.Create;

public class CreateCommentCommandHandler(ICommentService commentService) : IRequestHandler<CreateCommentCommand, Unit>
{
    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await commentService.AddAsync(request.Dto, request.UserId, cancellationToken);
        return Unit.Value;
    }
}