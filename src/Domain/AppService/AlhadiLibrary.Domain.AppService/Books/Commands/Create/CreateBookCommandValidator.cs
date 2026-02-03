using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Books.Commands.Create;

public class CreateBookCommandValidator
    : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Dto)
            .NotNull();

        RuleFor(x => x.Dto.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(300);

        RuleFor(x => x.Dto.Price)
            .GreaterThan(0)
            .WithMessage("قیمت باید بزرگتر از صفر باشد");

        RuleFor(x => x.Dto.PageCount)
            .GreaterThan(0)
            .WithMessage("تعداد صفحات نامعتبر است");

        RuleFor(x => x.Dto.CategoryId)
            .GreaterThan(0)
            .WithMessage("دسته‌بندی نامعتبر است");

        RuleFor(x => x.Dto.ImagePath)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Dto.AuthorIds)
            .NotNull()
            .Must(x => x.Any())
            .WithMessage("حداقل یک نویسنده الزامی است")
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("نویسندگان تکراری هستند");

        RuleFor(x => x.Dto.TranslatorIds)
            .Must(x => x.Distinct().Count() == x.Count)
            .When(x => x.Dto.TranslatorIds != null && x.Dto.TranslatorIds.Any())
            .WithMessage("مترجم‌های تکراری مجاز نیستند");
    }
}
