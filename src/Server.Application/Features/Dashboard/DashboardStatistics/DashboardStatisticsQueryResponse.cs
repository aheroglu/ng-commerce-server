namespace Server.Application.Features.Dashboard.DashboardStatistics;

public sealed record DashboardStatisticsQueryResponse(
    int? TotalProducts,
    int? TotalSales,
    int? TotalCustomers,
    decimal? TotalEarnings);
