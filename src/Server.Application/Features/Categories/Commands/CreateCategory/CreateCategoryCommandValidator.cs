using FluentValidation;

namespace Server.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(30);
        RuleFor(p => p.Image).NotEmpty().NotNull();
    }
}