using Gathering.Application.Authentication.Commands.Register;
using Gathering.Application.Authentication.Queries.Login;
using Gathering.Application.Services.Authentication;
using Gathering.Contracts.Authentication;
using Gathering.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gathering.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        
        var authResult = await _mediator.Send(command);
        
        if (authResult.IsError && authResult.FirstError == Errors.User.UserWithGivenEmailAlreadyExists)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        
        return authResult.Match(
            success => Ok(Create(success)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        
        var authResult = await _mediator.Send(query);
        
        return authResult.Match(
            success => Ok(Create(success)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse Create(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }
}