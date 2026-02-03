using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands.Create;

public class CreateCategoryCommandValidator
    : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Dto)
            .NotNull().WithMessage("اطلاعات دسته‌بندی الزامی است");

        RuleFor(x => x.Dto.Title)
            .NotEmpty().WithMessage("عنوان دسته‌بندی الزامی است")
            .MinimumLength(3).WithMessage("عنوان حداقل ۳ کاراکتر")
            .MaximumLength(200).WithMessage("عنوان حداکثر ۲۰۰ کاراکتر");

        RuleFor(x => x.Dto.ParentId)
            .GreaterThan(0)
            .When(x => x.Dto.ParentId.HasValue)
            .WithMessage("شناسه دسته‌بندی والد نامعتبر است");

        RuleFor(x => x.Dto.ImagePath)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Dto.ImagePath))
            .WithMessage("مسیر تصویر نامعتبر است");
    }
}
