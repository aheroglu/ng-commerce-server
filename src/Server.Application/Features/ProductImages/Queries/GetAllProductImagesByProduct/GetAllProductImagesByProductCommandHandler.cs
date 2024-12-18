using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.ProductImages.Queries.GetProductImagesByProduct;

internal sealed record GetAllProductImagesByProductCommandHandler(
    IQueryRepository<ProductImage> queryRepository) : IRequestHandler<GetAllProductImagesByProductCommand, Result<List<GetAllProductImagesByProductCommandResponse>>>
{
    public async Task<Result<List<GetAllProductImagesByProductCommandResponse>>> Handle(GetAllProductImagesByProductCommand request, CancellationToken cancellationToken)
    {
        var productImages = await queryRepository
            .QueryAll()
            .Include(p => p.Product)
            .Where(p => p.ProductId == request.ProductId)
            .ToListAsync(cancellationToken);

        return new(
            null,
            null,
            productImages.Adapt<List<GetAllProductImagesByProductCommandResponse>>());
    }
}