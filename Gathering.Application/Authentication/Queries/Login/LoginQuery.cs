using ErrorOr;
using Gathering.Application.Authentication.Common;
using MediatR;

namespace Gathering.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;