﻿using Gathering.Application.Authentication.Commands.Register;
using Gathering.Application.Authentication.Queries.Login;
using Gathering.Contracts.Authentication;
using Gathering.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gathering.Api.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest contractRequest)
    {
        var command = _mapper.Map<RegisterCommand>(contractRequest);

        var authResult = await _mediator.Send(command);

        if (authResult.IsError && authResult.FirstError == Errors.User.UserWithGivenEmailAlreadyExists)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest contractRequest)
    {
        var query = _mapper.Map<LoginQuery>(contractRequest);

        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}