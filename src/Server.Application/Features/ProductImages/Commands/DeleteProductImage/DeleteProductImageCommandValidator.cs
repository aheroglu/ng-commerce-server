using FluentValidation;

namespace Server.Application.Features.ProductImages.Commands.DeleteProductImage;

public sealed class DeleteProductImageCommandValidator : AbstractValidator<DeleteProductImageCommand>
{
    public DeleteProductImageCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();
    }
}