using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Books.Commands.Delete;

public class DeleteBookCommandValidator
    : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("شناسه کتاب نامعتبر است");
    }
}
