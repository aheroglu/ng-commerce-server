using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQuery : IRequest<Result<List<GetAllUsersQueryResponse>>>;
