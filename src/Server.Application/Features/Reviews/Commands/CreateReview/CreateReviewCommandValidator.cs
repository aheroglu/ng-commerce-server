using FluentValidation;

namespace Server.Application.Features.Reviews.Commands.CreateReview;

public sealed class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(p => p.Content).MinimumLength(5).MaximumLength(200);
        RuleFor(p => p.Rating).NotNull().NotEmpty().InclusiveBetween(1, 5);
        RuleFor(p => p.AppUserId).NotNull().NotEmpty();
        RuleFor(p => p.ProductId).NotNull().NotEmpty();
    }
}
