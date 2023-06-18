using Gathering.Application.Common.Interfaces.Authentication;
using Gathering.Application.Common.Interfaces.Persistence;
using Gathering.Domain.Entities;

namespace Gathering.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenProvider jwtTokenProvider, IUserRepository userRepository)
    {
        _jwtTokenProvider = jwtTokenProvider;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("User with given Email already exists");
        }

        //Create user
        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        //Generate token
        var token = _jwtTokenProvider.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetByEmail(email) is not User user)
        {
            throw new Exception("User with given Email does not exist");
        }

        var token =_jwtTokenProvider.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}