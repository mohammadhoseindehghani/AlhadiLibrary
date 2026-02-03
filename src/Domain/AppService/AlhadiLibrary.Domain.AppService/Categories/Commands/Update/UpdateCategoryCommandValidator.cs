using FluentValidation;

namespace AlhadiLibrary.Domain.AppService.Categories.Commands.Update;

public class UpdateCategoryCommandValidator
    : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Dto)
            .NotNull()
            .WithMessage("اطلاعات دسته‌بندی الزامی است");

        RuleFor(x => x.Dto.Id)
            .GreaterThan(0)
            .WithMessage("شناسه دسته‌بندی نامعتبر است");

        RuleFor(x => x.Dto.Title)
            .NotEmpty().WithMessage("عنوان دسته‌بندی الزامی است")
            .MinimumLength(3).WithMessage("عنوان دسته‌بندی حداقل ۳ کاراکتر است")
            .MaximumLength(200).WithMessage("عنوان دسته‌بندی حداکثر ۲۰۰ کاراکتر است");

        RuleFor(x => x.Dto.ParentId)
            .GreaterThan(0)
            .When(x => x.Dto.ParentId.HasValue)
            .WithMessage("شناسه دسته‌بندی والد نامعتبر است");

        RuleFor(x => x)
            .Must(x => x.Dto.ParentId == null || x.Dto.ParentId != x.Dto.Id)
            .WithMessage("دسته‌بندی نمی‌تواند والد خودش باشد");
    }
}
