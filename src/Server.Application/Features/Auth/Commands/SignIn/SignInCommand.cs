﻿using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Auth.Commands.SignIn;

public sealed record SignInCommand(
    string UserNameOrEmail,
    string Password) : IRequest<Result<SignInCommandResponse>>;