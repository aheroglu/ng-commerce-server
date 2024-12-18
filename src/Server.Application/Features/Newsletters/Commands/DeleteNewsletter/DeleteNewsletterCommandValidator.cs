using FluentValidation;

namespace Server.Application.Features.Newsletters.Commands.DeleteNewsletter;

public sealed class DeleteNewsletterCommandValidator : AbstractValidator<DeleteNewsletterCommand>
{
    public DeleteNewsletterCommandValidator()
    {
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
    }
}
