using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    string Id,
    string Name,
    string CategoryId,
    string BrandId,
    string Model,
    string Description,
    string Url,
    decimal Price,
    int Stock) : IRequest<Result<UpdateProductCommandResponse>>;
