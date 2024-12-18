using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Application.Common;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Queries.GetAllCustomers;

internal sealed class GetAllCustomerQueryHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<GetAllCustomersQuery, Result<List<GetAllCustomersQueryResponse>>>
{
    public async Task<Result<List<GetAllCustomersQueryResponse>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = mapper
            .Map<List<GetAllCustomersQueryResponse>>(await userManager
            .GetUsersInRoleAsync("Customer"));

        return Result<List<GetAllCustomersQueryResponse>>
            .Success(customers);
    }
}
