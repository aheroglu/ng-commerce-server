using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Addresses.Queries.GetAddressById;

public sealed record GetAddressByIdQuery(
    string Id) : IRequest<Result<GetAddressByIdQueryResponse>>;
