using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Dashboard.DashboardStatistics;

public sealed record DashboardStatisticsQuery : IRequest<Result<DashboardStatisticsQueryResponse>>;
