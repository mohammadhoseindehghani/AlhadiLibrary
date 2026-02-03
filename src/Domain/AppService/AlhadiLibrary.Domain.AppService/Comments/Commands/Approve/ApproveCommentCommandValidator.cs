using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Comments.Commands.Approve;

public class ApproveCommentCommandValidator
    : AbstractValidator<ApproveCommentCommand>
{
    public ApproveCommentCommandValidator()
    {
        RuleFor(x => x.CommentId)
            .GreaterThan(0)
            .WithMessage("شناسه کامنت نامعتبر است");
    }
}