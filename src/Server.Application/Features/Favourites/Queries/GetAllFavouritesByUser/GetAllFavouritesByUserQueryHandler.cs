using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Favourites.Queries.GetAllFavouritesByUser;

internal sealed class GetAllFavouritesByUserQueryHandler(
    IQueryRepository<Favourite> queryRepository) : IRequestHandler<GetAllFavouritesByUserQuery, Result<List<GetAllFavouritesByUserQueryResponse>>>
{
    public async Task<Result<List<GetAllFavouritesByUserQueryResponse>>> Handle(GetAllFavouritesByUserQuery request, CancellationToken cancellationToken)
    {
        var favourites = await queryRepository
            .QueryAll()
            .Include(p => p.AppUser)
            .Include(p => p.Product)
            .Include(p => p.Product.Category)
            .Where(p => p.AppUserId == request.AppUserId)
            .ToListAsync(cancellationToken);

        return Result<List<GetAllFavouritesByUserQueryResponse>>
            .Success(favourites.Adapt<List<GetAllFavouritesByUserQueryResponse>>());
    }
}
