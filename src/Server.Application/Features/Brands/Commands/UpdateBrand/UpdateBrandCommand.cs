using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Brands.Commands.UpdateBrand;

public sealed record UpdateBrandCommand(
    string Id,
    string Name) : IRequest<Result<UpdateBrandCommandResponse>>;
