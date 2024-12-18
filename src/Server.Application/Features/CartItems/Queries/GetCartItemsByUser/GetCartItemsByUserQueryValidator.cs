using FluentValidation;

namespace Server.Application.Features.CartItems.Queries.GetCartItemsByUser;

public sealed class GetCartItemsByUserQueryValidator : AbstractValidator<GetCartItemsByUserQuery>
{
    public GetCartItemsByUserQueryValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
    }
}
