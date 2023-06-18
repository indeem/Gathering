using Gathering.Domain.Entities;

namespace Gathering.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);