using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Newsletters.Queries.GetAllNewsletters;

public sealed record GetAllNewslettersQuery : IRequest<Result<List<GetAllNewslettersQueryResponse>>>;
