using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.CreditCards.Commands.DeleteCreditCard;

internal sealed class DeleteCreditCardCommandHandler(
    ICreditCardQueryRepository creditCardQueryRepository,
    ICreditCardCommandRepository creditCardCommandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCreditCardCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCreditCardCommand request, CancellationToken cancellationToken)
    {
        CreditCard creditCard = await creditCardQueryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (creditCard is null) return Result<string>
                .Failure("Credit card not found!");

        creditCardCommandRepository
            .Delete(creditCard);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success("Credit card was deleted successfully");
    }
}
