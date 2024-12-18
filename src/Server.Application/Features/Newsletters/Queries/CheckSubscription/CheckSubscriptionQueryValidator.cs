using FluentValidation;

namespace Server.Application.Features.Newsletters.Queries.CheckSubscription;

public sealed class CheckSubscriptionQueryValidator : AbstractValidator<CheckSubscriptionQuery>
{
    public CheckSubscriptionQueryValidator()
    {
        RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress();
    }
}
