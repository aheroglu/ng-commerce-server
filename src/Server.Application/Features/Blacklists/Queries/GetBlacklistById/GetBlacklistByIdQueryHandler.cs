using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Blacklists.Queries.GetBlacklistById;

internal sealed class GetBlacklistByIdQueryHandler(
    IQueryRepository<Blacklist> queryRepository,
    IMapper mapper) : IRequestHandler<GetBlacklistByIdQuery, Result<GetBlacklistByIdQueryResponse>>
{
    public async Task<Result<GetBlacklistByIdQueryResponse>> Handle(GetBlacklistByIdQuery request, CancellationToken cancellationToken)
    {
        var blacklist = mapper
            .Map<GetBlacklistByIdQueryResponse>(await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken, p => p.AppUser));

        if (blacklist is null) return Result<GetBlacklistByIdQueryResponse>
                .Failure("Blacklist record not found!");

        return Result<GetBlacklistByIdQueryResponse>
            .Success(blacklist);
    }
}
