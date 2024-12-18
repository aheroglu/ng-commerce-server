using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Messages.Queries.GetMessageById;

internal sealed class GetMessageByIdQueryHandler(
    IQueryRepository<Message> queryRepository) : IRequestHandler<GetMessageByIdQuery, Result<GetMessageByIdQueryResponse>>
{
    public async Task<Result<GetMessageByIdQueryResponse>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        Message message = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (message is null) return Result<GetMessageByIdQueryResponse>
                .Failure("Message not found!");

        return Result<GetMessageByIdQueryResponse>
            .Success(message.Adapt<GetMessageByIdQueryResponse>());
    }
}
