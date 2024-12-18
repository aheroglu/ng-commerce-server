using FluentValidation;

namespace Server.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(2);
        RuleFor(p => p.CategoryId).NotEmpty().NotNull();
        RuleFor(p => p.BrandId).NotEmpty().NotNull();
        RuleFor(p => p.Model).NotEmpty().NotNull();
        RuleFor(p => p.Description).NotEmpty().NotNull();
        RuleFor(p => p.Url).NotEmpty().NotNull();
        RuleFor(p => p.Price).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(p => p.Stock).NotNull().NotEmpty().GreaterThan(0);
    }
}
