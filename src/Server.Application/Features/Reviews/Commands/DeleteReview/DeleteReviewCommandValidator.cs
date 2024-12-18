using FluentValidation;

namespace Server.Application.Features.Reviews.Commands.DeleteReview;

public sealed class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();
    }
}
