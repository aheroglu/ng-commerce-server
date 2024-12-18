using FluentValidation;

namespace Server.Application.Features.Categories.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();
    }
}
