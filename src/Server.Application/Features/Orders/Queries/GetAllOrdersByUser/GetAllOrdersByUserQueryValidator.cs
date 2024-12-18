using FluentValidation;

namespace Server.Application.Features.Orders.Queries.GetAllOrdersByUser;

public sealed class GetAllOrdersByUserQueryValidator : AbstractValidator<GetAllOrdersByUserQuery>
{
    public GetAllOrdersByUserQueryValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
    }
}
