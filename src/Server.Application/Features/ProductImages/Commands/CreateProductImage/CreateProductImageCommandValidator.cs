using FluentValidation;

namespace Server.Application.Features.ProductImages.Commands.CreateProductImage;

public sealed class CreateProductImageCommandValidator : AbstractValidator<CreateProductImageCommand>
{
    public CreateProductImageCommandValidator()
    {
        RuleFor(p => p.Image).NotEmpty().NotEmpty();
        RuleFor(p => p.ProductId).NotEmpty().NotEmpty();
    }
}
