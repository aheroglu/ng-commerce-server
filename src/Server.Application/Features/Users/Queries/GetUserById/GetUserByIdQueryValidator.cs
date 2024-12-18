using FluentValidation;

namespace Server.Application.Features.Users.Queries.GetUserById;

public sealed class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
    }
}
