using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Messages.Queries.GetMessageById;

public sealed record GetMessageByIdQuery(
    string Id) : IRequest<Result<GetMessageByIdQueryResponse>>;
