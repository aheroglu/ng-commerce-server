using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Dashboard.DashboardStatistics;

internal sealed class DashboardStatisticsQueryHandler(
    IProductQueryRepository productQueryRepository,
    UserManager<AppUser> userManager) : IRequestHandler<DashboardStatisticsQuery, Result<DashboardStatisticsQueryResponse>>
{
    public async Task<Result<DashboardStatisticsQueryResponse>> Handle(DashboardStatisticsQuery request, CancellationToken cancellationToken)
    {
        var totalProducts = await productQueryRepository
            .QueryAll()
            .CountAsync();

        var totalCustomers = userManager
            .GetUsersInRoleAsync("Customer")
            .Result
            .Count();

        var response = new DashboardStatisticsQueryResponse(
            totalProducts,
            null,
            totalCustomers,
            null);

        return Result<DashboardStatisticsQueryResponse>
            .Success(response);
    }
}
