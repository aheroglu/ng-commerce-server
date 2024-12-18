using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Favourites.Queries.GetFavouriteById;

internal sealed class GetFavouriteByIdQueryHandler(
    IQueryRepository<Favourite> queryRepository) : IRequestHandler<GetFavouriteByIdQuery, Result<GetFavouriteByIdQueryResponse>>
{
    public async Task<Result<GetFavouriteByIdQueryResponse>> Handle(GetFavouriteByIdQuery request, CancellationToken cancellationToken)
    {
        Favourite favourite = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken, p => p.AppUser, p => p.Product.Category, p => p.Product.Brand);

        if (favourite is null) return Result<GetFavouriteByIdQueryResponse>
                .Failure("Favourite not found!");

        return Result<GetFavouriteByIdQueryResponse>
            .Success(favourite.Adapt<GetFavouriteByIdQueryResponse>());
    }
}
