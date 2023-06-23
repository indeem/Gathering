using ErrorOr;
using Gathering.Application.Authentication.Common;
using MediatR;

namespace Gathering.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;