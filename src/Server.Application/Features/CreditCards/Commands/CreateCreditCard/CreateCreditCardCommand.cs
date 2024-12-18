using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CreditCards.Commands.CreateCreditCard;

public sealed record CreateCreditCardCommand(
    string AppUserId,
    string HolderName,
    string Number,
    string ExpirationMonth,
    string ExpirationYear,
    string CVV) : IRequest<Result<string>>;
