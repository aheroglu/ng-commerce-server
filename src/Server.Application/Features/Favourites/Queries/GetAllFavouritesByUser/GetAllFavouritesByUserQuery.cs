using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Favourites.Queries.GetAllFavouritesByUser;

public sealed record GetAllFavouritesByUserQuery(
    string AppUserId) : IRequest<Result<List<GetAllFavouritesByUserQueryResponse>>>;
