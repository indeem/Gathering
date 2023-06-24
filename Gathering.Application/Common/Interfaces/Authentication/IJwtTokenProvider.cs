using Gathering.Domain.User;

namespace Gathering.Application.Common.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken (User user);
}