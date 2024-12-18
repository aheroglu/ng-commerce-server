using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Messages.Queries.GetAllMessages;

public sealed record GetAllMessagesQuery : IRequest<Result<List<GetAllMessagesQueryResponse>>>;
