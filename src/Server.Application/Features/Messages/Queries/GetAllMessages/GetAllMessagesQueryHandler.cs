using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Messages.Queries.GetAllMessages;

internal sealed record GetAllMessagesQueryHandler(
    IQueryRepository<Message> queryRepository,
    IMapper mapper) : IRequestHandler<GetAllMessagesQuery, Result<List<GetAllMessagesQueryResponse>>>
{
    public async Task<Result<List<GetAllMessagesQueryResponse>>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = mapper.Map<List<GetAllMessagesQueryResponse>>(await queryRepository
            .GetAllAsync(cancellationToken));

        return Result<List<GetAllMessagesQueryResponse>>
            .Success(messages);
    }
}
