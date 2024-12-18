using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.ProductImages.Queries.GetProductImagesByProduct;

public sealed record GetAllProductImagesByProductCommand(
    string ProductId) : IRequest<Result<List<GetAllProductImagesByProductCommandResponse>>>;
