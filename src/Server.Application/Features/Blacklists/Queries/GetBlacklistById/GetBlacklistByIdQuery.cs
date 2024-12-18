using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Blacklists.Queries.GetBlacklistById;

public sealed record GetBlacklistByIdQuery(
    string Id) : IRequest<Result<GetBlacklistByIdQueryResponse>>;
