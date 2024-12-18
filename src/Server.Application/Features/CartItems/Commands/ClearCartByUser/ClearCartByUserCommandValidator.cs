using FluentValidation;

namespace Server.Application.Features.CartItems.Commands.ClearCartByUser;

public sealed class ClearCartByUserCommandValidator : AbstractValidator<ClearCartByUserCommand>
{
    public ClearCartByUserCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
    }
}
