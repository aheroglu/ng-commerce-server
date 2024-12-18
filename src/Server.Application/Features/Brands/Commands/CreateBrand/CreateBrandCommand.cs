using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Brands.Commands.CreateBrand;

public sealed record CreateBrandCommand(
    string Name) : IRequest<Result<CreateBrandCommandResponse>>;
