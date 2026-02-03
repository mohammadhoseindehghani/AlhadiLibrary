using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands.Delete;

public class DeleteCategoryCommandValidator
    : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("شناسه دسته‌بندی نامعتبر است");
    }
}
