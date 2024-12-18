using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Addresses.Queries.GetAllAddressesByUser;

internal sealed class GetAllAddressesByUserQueryHandler(
    IQueryRepository<Address> queryRepository,
    IMapper mapper) : IRequestHandler<GetAllAddressesByUserQuery, Result<List<GetAllAddressesByUserQueryResponse>>>
{
    public async Task<Result<List<GetAllAddressesByUserQueryResponse>>> Handle(GetAllAddressesByUserQuery request, CancellationToken cancellationToken)
    {
        var addresses = mapper
            .Map<List<GetAllAddressesByUserQueryResponse>>(await queryRepository
            .QueryAll()
            .Include(p => p.AppUser)
            .Where(p => p.AppUserId == request.AppUserId)
            .ToListAsync(cancellationToken));

        return Result<List<GetAllAddressesByUserQueryResponse>>
            .Success(addresses);
    }
}
