using FluentValidation;

namespace Server.Application.Features.Addresses.Commands.UpdateAddress;

public sealed class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.Street).NotEmpty().NotNull();
        RuleFor(p => p.City).NotEmpty().NotNull();
        RuleFor(p => p.District).NotEmpty().NotNull();
        RuleFor(p => p.PostalCode).NotEmpty().NotNull();
        RuleFor(p => p.FullAddress).NotEmpty().NotNull();
        RuleFor(p => p.AddressType).NotEmpty().NotNull();
    }
}
