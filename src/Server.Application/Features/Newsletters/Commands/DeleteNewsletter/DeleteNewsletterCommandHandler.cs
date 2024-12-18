using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Newsletters.Commands.DeleteNewsletter;

public sealed class DeleteNewsletterCommandHandler(
    IQueryRepository<Newsletter> queryRepository,
    ICommandRepository<Newsletter> commandRepository,
    UserManager<AppUser> userManager,
    IEmailService emailService,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteNewsletterCommand, Result<DeleteNewsletterCommandResponse>>
{
    public async Task<Result<DeleteNewsletterCommandResponse>> Handle(DeleteNewsletterCommand request, CancellationToken cancellationToken)
    {
        Newsletter newsletter = await queryRepository
            .GetByAsync(p => p.Email == request.Email, cancellationToken);

        if (newsletter is null) return Result<DeleteNewsletterCommandResponse>
                .Failure("Newsletter not found!");

        commandRepository
            .Delete(newsletter);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        AppUser? user = await userManager
           .Users
           .FirstOrDefaultAsync(p => p.Email == request.Email, cancellationToken);

        if (user is null) return Result<DeleteNewsletterCommandResponse>
                .Failure("User not found!");

        string body = @"
        <h1>You Have Left Our Newsletter</h1>
        <p>You have left our newsletter. See you again.</p>";

        emailService
            .SendEmail(
                user.FullName,
                request.Email,
                "Newsletter Unsubscription Successful",
                body);

        return Result<DeleteNewsletterCommandResponse>
            .Success(
                "Successfully unsubscribed",
                newsletter.Adapt<DeleteNewsletterCommandResponse>());
    }
}
