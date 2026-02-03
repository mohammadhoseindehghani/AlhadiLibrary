using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Comments.Commands.Create;

public class CreateCommentCommand : IRequest<Unit>
{
    public int UserId { get; set; }
    public CreateCommentDto Dto { get; set; }
}