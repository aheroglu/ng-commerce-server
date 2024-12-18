using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Repositories;

namespace Server.Application.Features.CartItems.Queries.GetCartItemsByUser;

internal sealed class GetCartItemsByUserQueryHandler(
    ICartItemQueryRepository cartItemQueryRepository,
    IMapper mapper) : IRequestHandler<GetCartItemsByUserQuery, Result<List<GetCartItemsByUserQueryResponse>>>
{
    public async Task<Result<List<GetCartItemsByUserQueryResponse>>> Handle(GetCartItemsByUserQuery request, CancellationToken cancellationToken)
    {
        var cartItems = mapper
            .Map<List<GetCartItemsByUserQueryResponse>>(await cartItemQueryRepository
            .QueryAll()
            .Include(p => p.Product)
            .ThenInclude(p => p.ProductImages)
            .Include(p => p.AppUser)
            .Where(p => p.AppUserId == request.AppUserId)
            .ToListAsync());

        return Result<List<GetCartItemsByUserQueryResponse>>
            .Success(cartItems);
    }
}
