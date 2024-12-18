using FluentValidation;

namespace Server.Application.Features.Users.Commands.DeleteUser;

public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
    }
}
