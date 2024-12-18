using MediatR;
using Microsoft.AspNetCore.Http;
using Server.Application.Common;

namespace Server.Application.Features.Categories.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(
    string Id,
    string Name,
    IFormFile? Image) : IRequest<Result<UpdateCategoryCommandResponse>>;