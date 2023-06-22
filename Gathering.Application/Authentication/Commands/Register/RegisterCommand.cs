using ErrorOr;
using Gathering.Application.Services.Authentication;
using MediatR;

namespace Gathering.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;