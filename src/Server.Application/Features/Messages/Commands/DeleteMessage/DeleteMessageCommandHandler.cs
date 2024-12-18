using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Messages.Commands.DeleteMessage;

internal sealed class DeleteMessageCommandHandler(
    IQueryRepository<Message> queryRepository,
    ICommandRepository<Message> commandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteMessageCommand, Result<DeleteMessageCommandResponse>>
{
    public async Task<Result<DeleteMessageCommandResponse>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        Message message = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (message is null) return Result<DeleteMessageCommandResponse>
                .Failure("Message not found!");

        commandRepository
            .Delete(message);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<DeleteMessageCommandResponse>
            .Success(
                "Message was successfully deleted",
                message.Adapt<DeleteMessageCommandResponse>());
    }
}
