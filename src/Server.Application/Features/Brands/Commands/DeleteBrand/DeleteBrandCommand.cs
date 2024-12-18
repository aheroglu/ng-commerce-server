using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Brands.Commands.DeleteBrand;

public sealed record DeleteBrandCommand(
    string Id) : IRequest<Result<DeleteBrandCommandResponse>>;
