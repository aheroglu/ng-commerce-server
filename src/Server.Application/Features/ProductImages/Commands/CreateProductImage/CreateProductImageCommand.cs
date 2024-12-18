using MediatR;
using Microsoft.AspNetCore.Http;
using Server.Application.Common;

namespace Server.Application.Features.ProductImages.Commands.CreateProductImage;

public sealed record CreateProductImageCommand(
    IFormFile Image,
    string ProductId) : IRequest<Result<CreateProductImageCommandResponse>>;
