namespace Gathering.Application.Common.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken (Guid userId, string email);
}