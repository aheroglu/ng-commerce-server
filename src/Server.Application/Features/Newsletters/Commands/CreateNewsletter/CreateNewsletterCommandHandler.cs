using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Newsletters.Commands.CreateNewsletter;

internal sealed class CreateNewsletterCommandHandler(
    INewsletterCommandRepository commandRepository,
    INewsletterQueryRepository queryRepository,
    IUnitOfWork unitOfWork,
    IEmailService emailService,
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<CreateNewsletterCommand, Result<CreateNewsletterCommandResponse>>
{
    public async Task<Result<CreateNewsletterCommandResponse>> Handle(CreateNewsletterCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExists = await queryRepository
            .IsEmailExistsAsync(request.Email, cancellationToken);

        if (isEmailExists) return Result<CreateNewsletterCommandResponse>
                .Failure("This email already subscribed!");

        Newsletter newsletter = mapper
            .Map<Newsletter>(request);

        await commandRepository
            .CreateAsync(newsletter);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Email == request.Email, cancellationToken);

        if (user is null) return Result<CreateNewsletterCommandResponse>
                .Failure("User not found!");

        string body = @"
        <h1>Thanks For Subscribe Our Newsletter!</h1>
        <p>You have subscribed our newsletter. Now you can get access to discounts, coupon codes and more before anyone else.</p>";

        emailService
            .SendEmail(
                user.FullName,
                request.Email,
                "Newsletter Subscription Successful",
                body);

        return Result<CreateNewsletterCommandResponse>
            .Success(
                "Successfully subscribed to newsletter",
                newsletter.Adapt<CreateNewsletterCommandResponse>());
    }
}
