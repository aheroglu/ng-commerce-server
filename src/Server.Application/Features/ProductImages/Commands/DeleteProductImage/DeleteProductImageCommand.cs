using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.ProductImages.Commands.DeleteProductImage;

public sealed record DeleteProductImageCommand(
    string Id) : IRequest<Result<DeleteProductImageCommandResponse>>;
