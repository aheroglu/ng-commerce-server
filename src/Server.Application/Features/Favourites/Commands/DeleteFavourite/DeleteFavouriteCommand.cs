using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Favourites.Commands.DeleteFavourite;

public sealed record DeleteFavouriteCommand(
    string Id) : IRequest<Result<DeleteFavouriteCommandResponse>>;
