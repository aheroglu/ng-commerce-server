using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Products.Commands.DeleteProductById;

public sealed record DeleteProductByIdCommand(
    string Id) : IRequest<Result<DeleteProductByIdCommandResponse>>;
