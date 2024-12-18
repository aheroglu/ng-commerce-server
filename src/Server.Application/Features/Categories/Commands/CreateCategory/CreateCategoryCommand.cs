using MediatR;
using Microsoft.AspNetCore.Http;
using Server.Application.Common;

namespace Server.Application.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    string Name,
    IFormFile Image) : IRequest<Result<CreateCategoryCommandResponse>>;
