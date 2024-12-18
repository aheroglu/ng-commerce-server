using FluentValidation;

namespace Server.Application.Features.Brands.Commands.CreateBrand;

public sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull();
    }
}
