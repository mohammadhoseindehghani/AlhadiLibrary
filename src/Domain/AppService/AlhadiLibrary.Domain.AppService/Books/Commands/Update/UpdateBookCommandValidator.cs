using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Books.Commands.Update;

public class UpdateBookCommandValidator
    : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Dto)
            .NotNull()
            .WithMessage("اطلاعات کتاب الزامی است");

        RuleFor(x => x.Dto.Id)
            .GreaterThan(0)
            .WithMessage("شناسه کتاب نامعتبر است");

        RuleFor(x => x.Dto.Title)
            .NotEmpty().WithMessage("عنوان کتاب الزامی است")
            .MinimumLength(2).WithMessage("عنوان کتاب حداقل ۲ کاراکتر است")
            .MaximumLength(300).WithMessage("عنوان کتاب حداکثر ۳۰۰ کاراکتر است");

        RuleFor(x => x.Dto.Price)
            .GreaterThan(0)
            .WithMessage("قیمت کتاب باید بزرگتر از صفر باشد");

        RuleFor(x => x.Dto.PageCount)
            .GreaterThan(0)
            .WithMessage("تعداد صفحات کتاب نامعتبر است");

        RuleFor(x => x.Dto.CategoryId)
            .GreaterThan(0)
            .WithMessage("دسته‌بندی انتخاب‌شده نامعتبر است");

        RuleFor(x => x.Dto.AuthorIds)
            .NotNull()
            .WithMessage("لیست نویسندگان الزامی است")
            .Must(x => x.Any())
            .WithMessage("کتاب باید حداقل یک نویسنده داشته باشد")
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("نویسندگان تکراری هستند");

        RuleFor(x => x.Dto.TranslatorIds)
            .Must(x => x.Distinct().Count() == x.Count)
            .When(x => x.Dto.TranslatorIds.Any())
            .WithMessage("مترجم‌های تکراری مجاز نیستند");
    }
}

