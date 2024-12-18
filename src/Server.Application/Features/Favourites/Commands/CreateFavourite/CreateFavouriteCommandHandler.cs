using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Favourites.Commands.CreateFavourite;

internal sealed class CreateFavouriteCommandHandler(
    IFavouriteQueryRepository favouriteQueryRepository,
    IFavouriteCommandRepository favouriteCommandRepository,
    IProductQueryRepository productQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateFavouriteCommand, Result<CreateFavouriteCommandResponse>>
{
    public async Task<Result<CreateFavouriteCommandResponse>> Handle(CreateFavouriteCommand request, CancellationToken cancellationToken)
    {
        bool isFavouriteExists = await favouriteQueryRepository
            .IsFavouriteExists(request.ProductId, request.AppUserId, cancellationToken);

        if (isFavouriteExists) return Result<CreateFavouriteCommandResponse>
                .Failure("You already added this products your favourites");

        Favourite favourite = mapper.Map<Favourite>(request);

        Product product = await productQueryRepository
            .GetByAsync(p => p.Id == request.ProductId, cancellationToken);

        favourite.PriceWhenAdded = product.Price;

        await favouriteCommandRepository
            .CreateAsync(favourite, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<CreateFavouriteCommandResponse>
            .Success(
                "Product was added to your favourites",
                favourite.Adapt<CreateFavouriteCommandResponse>());
    }
}
