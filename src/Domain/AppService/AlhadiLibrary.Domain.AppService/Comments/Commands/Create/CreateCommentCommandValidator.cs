using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Comments.Commands.Create;

public class CreateCommentCommandValidator
    : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("یوزر آیدی اجباری است");

        RuleFor(x => x.Dto)
            .NotNull();

        RuleFor(x => x.Dto.Text)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(500);

        RuleFor(x => x.Dto.BookId)
            .GreaterThan(0);
    }
}