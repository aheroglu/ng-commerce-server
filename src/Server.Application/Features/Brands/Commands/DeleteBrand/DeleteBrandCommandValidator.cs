using FluentValidation;

namespace Server.Application.Features.Brands.Commands.DeleteBrand;

public sealed class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
    }
}