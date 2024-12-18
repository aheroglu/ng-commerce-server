using FluentValidation;

namespace Server.Application.Features.OrderItems.Commands.CreateOrderItem;

public sealed class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemCommandValidator()
    {
        RuleFor(p => p.OrderId).NotEmpty().NotNull();
        RuleFor(p => p.ProductId).NotEmpty().NotNull();
        RuleFor(p => p.Quantity).NotEmpty().NotNull();
        RuleFor(p => p.TotalPrice).NotEmpty().NotNull();
    }
}
