using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CreditCards.Commands.DeleteCreditCard;

public sealed record DeleteCreditCardCommand(
    string Id) : IRequest<Result<string>>;
