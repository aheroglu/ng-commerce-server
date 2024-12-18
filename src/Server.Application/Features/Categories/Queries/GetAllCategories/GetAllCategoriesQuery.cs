using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Categories.Queries.GetAllCategories;

public sealed record GetAllCategoriesQuery : IRequest<Result<List<GetAllCategoriesQueryResponse>>>;