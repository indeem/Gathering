using MediatR;
using ErrorOr;
using Gathering.Application.Authentication.Common;

namespace Gathering.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;