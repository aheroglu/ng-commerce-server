using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Blacklists.Queries.GetAllBlacklist;

public sealed record GetAllBlacklistQuery : IRequest<Result<List<GetAllBlacklistQueryResponse>>>;
