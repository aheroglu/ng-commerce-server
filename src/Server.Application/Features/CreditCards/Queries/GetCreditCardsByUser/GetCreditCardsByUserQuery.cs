using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CreditCards.Queries.GetCreditCardsByUser;

public sealed record GetCreditCardsByUserQuery(
    string AppUserId) : IRequest<Result<List<GetCreditCardsByUserQueryResponse>>>;
