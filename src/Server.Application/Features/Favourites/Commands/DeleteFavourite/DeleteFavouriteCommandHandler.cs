using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Favourites.Commands.DeleteFavourite;

internal sealed class DeleteFavouriteCommandHandler(
    ICommandRepository<Favourite> commandRepository,
    IQueryRepository<Favourite> queryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteFavouriteCommand, Result<DeleteFavouriteCommandResponse>>
{
    public async Task<Result<DeleteFavouriteCommandResponse>> Handle(DeleteFavouriteCommand request, CancellationToken cancellationToken)
    {
        Favourite favourite = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (favourite is null) return Result<DeleteFavouriteCommandResponse>
                .Failure("Favourite not found!");

        commandRepository
            .Delete(favourite);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<DeleteFavouriteCommandResponse>
            .Success(
                "Product was successfully removed from your favourites",
                favourite.Adapt<DeleteFavouriteCommandResponse>());
    }
}
