using FluentValidation;

namespace Server.Application.Features.Roles.Commands.CreateRole;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull();
    }
}
