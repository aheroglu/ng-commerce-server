using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Messages.Commands.CreateMessage;

internal sealed class CreateMessageCommandHandler(
    ICommandRepository<Message> commandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateMessageCommand, Result<CreateMessageCommandResponse>>
{
    public async Task<Result<CreateMessageCommandResponse>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        Message message = mapper
            .Map<Message>(request);

        await commandRepository
            .CreateAsync(message, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<CreateMessageCommandResponse>
            .Success(
                "Message was successfully sent",
                message.Adapt<CreateMessageCommandResponse>());
    }
}
