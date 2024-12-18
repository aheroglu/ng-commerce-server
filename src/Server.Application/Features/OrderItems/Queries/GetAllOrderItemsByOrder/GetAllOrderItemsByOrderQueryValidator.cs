using FluentValidation;

namespace Server.Application.Features.OrderItems.Queries.GetAllOrderItemsByOrder;

public sealed class GetAllOrderItemsByOrderQueryValidator : AbstractValidator<GetAllOrderItemsByOrderQuery>
{
    public GetAllOrderItemsByOrderQueryValidator()
    {
        RuleFor(p => p.OrderId).NotEmpty().NotNull();
    }
}
