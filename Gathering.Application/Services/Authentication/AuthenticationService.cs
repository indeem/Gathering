using Gathering.Application.Common.Interfaces.Authentication;

namespace Gathering.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenProvider _jwtTokenProvider;

    public AuthenticationService(IJwtTokenProvider jwtTokenProvider)
    {
        _jwtTokenProvider = jwtTokenProvider;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists
        
        //Create user
        
        //Generate token
        var userId = Guid.NewGuid();
        var token = _jwtTokenProvider.GenerateToken(userId, email);
        
        return new AuthenticationResult(userId, firstName, lastName, email, "token");
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }
}