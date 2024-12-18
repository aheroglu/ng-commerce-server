using FluentValidation;

namespace Server.Application.Features.CreditCards.Queries.GetCreditCardsByUser;

public sealed class GetCreditCardsByUserQueryValidator : AbstractValidator<GetCreditCardsByUserQuery>
{
    public GetCreditCardsByUserQueryValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
    }
}
