using FluentValidation;

namespace Server.Application.Features.Products.Commands.DeleteProductById;

public sealed class DeleteProductByIdCommandValidator : AbstractValidator<DeleteProductByIdCommand>
{
    public DeleteProductByIdCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
    }
}
