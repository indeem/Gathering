using Gathering.Application.Services.Authentication;
using MediatR;
using ErrorOr;

namespace Gathering.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;