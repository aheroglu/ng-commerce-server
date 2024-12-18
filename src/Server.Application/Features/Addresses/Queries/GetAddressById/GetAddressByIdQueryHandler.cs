using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Addresses.Queries.GetAddressById;

internal sealed class GetAddressByIdQueryHandler(
    IQueryRepository<Address> queryRepository,
    IMapper mapper) : IRequestHandler<GetAddressByIdQuery, Result<GetAddressByIdQueryResponse>>
{
    public async Task<Result<GetAddressByIdQueryResponse>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = mapper
            .Map<GetAddressByIdQueryResponse>(await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken, p => p.AppUser));

        if (address is null) return Result<GetAddressByIdQueryResponse>
                .Failure("Address not found!");

        return Result<GetAddressByIdQueryResponse>
            .Success(address);
    }
}
