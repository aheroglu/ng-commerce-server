using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Repositories;

namespace Server.Application.Features.CreditCards.Queries.GetCreditCardsByUser;

internal sealed class GetCreditCardsByUserQueryHandler(
    ICreditCardQueryRepository creditCardQueryRepository,
    IMapper mapper) : IRequestHandler<GetCreditCardsByUserQuery, Result<List<GetCreditCardsByUserQueryResponse>>>
{
    public async Task<Result<List<GetCreditCardsByUserQueryResponse>>> Handle(GetCreditCardsByUserQuery request, CancellationToken cancellationToken)
    {
        var creditCards = mapper
            .Map<List<GetCreditCardsByUserQueryResponse>>(await creditCardQueryRepository
            .GetAllCreditCardsByUser(request.AppUserId, cancellationToken));

        return Result<List<GetCreditCardsByUserQueryResponse>>
            .Success(creditCards);
    }
}
