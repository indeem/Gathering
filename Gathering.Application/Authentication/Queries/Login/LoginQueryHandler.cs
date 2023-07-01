using ErrorOr;
using Gathering.Application.Authentication.Common;
using Gathering.Application.Common.Interfaces.Authentication;
using Gathering.Application.Common.Interfaces.Persistence;
using Gathering.Domain.Common.Errors;
using Gathering.Domain.User;
using MediatR;

namespace Gathering.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenProvider jwtTokenProvider, IUserRepository userRepository)
    {
        _jwtTokenProvider = jwtTokenProvider;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmail(query.Email) is not User user) return Errors.Authentication.InvalidCredentials;

        if (!user.Password.Equals(query.Password)) return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenProvider.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}