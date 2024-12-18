using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Users.Queries.GetAllCustomers;

public sealed record GetAllCustomersQuery : IRequest<Result<List<GetAllCustomersQueryResponse>>>;
