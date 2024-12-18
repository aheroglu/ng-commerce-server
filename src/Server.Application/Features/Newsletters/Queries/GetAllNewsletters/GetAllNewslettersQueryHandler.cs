using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Newsletters.Queries.GetAllNewsletters;

internal sealed class GetAllNewslettersQueryHandler(
    IQueryRepository<Newsletter> queryRepository,
    IMapper mapper) : IRequestHandler<GetAllNewslettersQuery, Result<List<GetAllNewslettersQueryResponse>>>
{
    public async Task<Result<List<GetAllNewslettersQueryResponse>>> Handle(GetAllNewslettersQuery request, CancellationToken cancellationToken)
    {
        var newsletters = mapper
            .Map<List<GetAllNewslettersQueryResponse>>(await queryRepository
            .GetAllAsync(cancellationToken));

        return Result<List<GetAllNewslettersQueryResponse>>
            .Success(newsletters);
    }
}
