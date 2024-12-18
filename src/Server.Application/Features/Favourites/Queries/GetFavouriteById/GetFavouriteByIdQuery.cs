using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Favourites.Queries.GetFavouriteById;

public sealed record GetFavouriteByIdQuery(
    string Id) : IRequest<Result<GetFavouriteByIdQueryResponse>>;
