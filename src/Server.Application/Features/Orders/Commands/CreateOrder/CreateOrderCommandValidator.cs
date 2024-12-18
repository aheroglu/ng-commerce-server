using FluentValidation;

namespace Server.Application.Features.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.AddressId).NotEmpty().NotNull();
        RuleFor(p => p.CreditCardId).NotEmpty().NotNull();
        RuleFor(p => p.OrderStatus).NotEmpty().NotNull();
        RuleFor(p => p.TotalPrice).NotEmpty().NotNull();
    }
}
