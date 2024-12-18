using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Categories.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(
    string Id) : IRequest<Result<DeleteCategoryCommandResponse>>;
