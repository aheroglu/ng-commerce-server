using FluentValidation;

namespace Server.Application.Features.Favourites.Commands.CreateFavourite;

public sealed class CreateFavouriteCommandValidator : AbstractValidator<CreateFavouriteCommand>
{
    public CreateFavouriteCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.ProductId).NotEmpty().NotNull();
        RuleFor(p => p.PriceWhenAdded).NotEmpty().NotNull();
    }
}
