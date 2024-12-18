using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Addresses.Queries.GetAllAddressesByUser;

public sealed record GetAllAddressesByUserQuery(
    string AppUserId) : IRequest<Result<List<GetAllAddressesByUserQueryResponse>>>;
