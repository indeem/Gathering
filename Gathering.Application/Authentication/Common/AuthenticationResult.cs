using Gathering.Domain.User;

namespace Gathering.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);