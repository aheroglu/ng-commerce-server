using FluentValidation;

namespace Server.Application.Features.Addresses.Commands.DeleteAddress;

public sealed class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
    }
}
