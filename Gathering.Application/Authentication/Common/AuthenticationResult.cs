using Gathering.Domain.Entities;

namespace Gathering.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);