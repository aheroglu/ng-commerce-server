using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Blacklists.Queries.GetAllBlacklist;

internal sealed class GetAllBlacklistQueryHandler(
    IQueryRepository<Blacklist> queryRepository,
    IMapper mapper) : IRequestHandler<GetAllBlacklistQuery, Result<List<GetAllBlacklistQueryResponse>>>
{
    public async Task<Result<List<GetAllBlacklistQueryResponse>>> Handle(GetAllBlacklistQuery request, CancellationToken cancellationToken)
    {
        var blacklists = mapper
            .Map<List<GetAllBlacklistQueryResponse>>(await queryRepository
            .GetAllAsync(cancellationToken, p => p.AppUser));

        return Result<List<GetAllBlacklistQueryResponse>>
            .Success(blacklists);
    }
}
