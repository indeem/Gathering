using Gathering.Domain.Entities;

namespace Gathering.Application.Common.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken (User user);
}