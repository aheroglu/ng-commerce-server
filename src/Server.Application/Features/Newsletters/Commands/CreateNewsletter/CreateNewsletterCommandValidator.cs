using FluentValidation;

namespace Server.Application.Features.Newsletters.Commands.CreateNewsletter;

public sealed class CreateNewsletterCommandValidator : AbstractValidator<CreateNewsletterCommand>
{
    public CreateNewsletterCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress();
    }
}
