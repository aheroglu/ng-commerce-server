using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(
    string AppUserId) : IRequest<Result<GetUserByIdQueryResponse>>;
