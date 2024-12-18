using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string CategoryId,
    string BrandId,
    string Model,
    string Description,
    string Url,
    decimal Price,
    int Stock) : IRequest<Result<CreateProductCommandResponse>>;