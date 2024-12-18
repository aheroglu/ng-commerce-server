using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.CreditCards.Commands.CreateCreditCard;

internal sealed class CreateCreditCardCommandHandler(
    ICreditCardQueryRepository creditCardQueryRepository,
    ICreditCardCommandRepository creditCardCommandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCreditCardCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
        bool isCreditCardExists = await creditCardQueryRepository
            .IsCreditCardExists(request.AppUserId, request.Number, request.ExpirationMonth, request.ExpirationYear, request.CVV, cancellationToken);

        if (isCreditCardExists) return Result<string>
                .Failure("Credit card already exists!");

        CreditCard creditCard = mapper
            .Map<CreditCard>(request);

        await creditCardCommandRepository
            .CreateAsync(creditCard, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success("Credit card was created successfully");
    }
}
