using FluentValidation;

namespace Server.Application.Features.Orders.Queries.GetOrderById;

public sealed class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(p => p.OrderId).NotNull().NotEmpty();
    }
}
