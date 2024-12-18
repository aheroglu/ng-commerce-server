using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Addresses.Commands.DeleteAddress;

public sealed record DeleteAddressCommand(
    string Id) : IRequest<Result<DeleteAddressCommandResponse>>;
