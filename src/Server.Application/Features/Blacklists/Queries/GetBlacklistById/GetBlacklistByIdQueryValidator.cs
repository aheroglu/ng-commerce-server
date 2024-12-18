using FluentValidation;

namespace Server.Application.Features.Blacklists.Queries.GetBlacklistById;

public sealed class GetBlacklistByIdQueryValidator : AbstractValidator<GetBlacklistByIdQuery>
{
    public GetBlacklistByIdQueryValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
    }
}
