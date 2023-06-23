using ErrorOr;
using Gathering.Application.Authentication.Common;
using Gathering.Application.Common.Interfaces.Authentication;
using Gathering.Application.Common.Interfaces.Persistence;
using Gathering.Domain.Common.Errors;
using Gathering.Domain.Entities;
using MediatR;

namespace Gathering.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider)
    {
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check if user exists
        if (_userRepository.GetByEmail(command.Email) is not null)
        {
            return Errors.User.UserWithGivenEmailAlreadyExists;
        }

        //Create user
        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        _userRepository.Add(user);

        //Generate token
        var token = _jwtTokenProvider.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}