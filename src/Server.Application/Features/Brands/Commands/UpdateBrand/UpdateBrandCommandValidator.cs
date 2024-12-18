using FluentValidation;

namespace Server.Application.Features.Brands.Commands.UpdateBrand;

public sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull();
    }
}
