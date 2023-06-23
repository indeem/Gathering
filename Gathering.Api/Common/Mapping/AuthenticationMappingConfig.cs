using Gathering.Application.Authentication.Commands.Register;
using Gathering.Application.Authentication.Common;
using Gathering.Application.Authentication.Queries.Login;
using Gathering.Contracts.Authentication;
using Mapster;

namespace Gathering.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>()
            .MapToConstructor(true);
        
        config.NewConfig<LoginRequest, LoginQuery>()
            .MapToConstructor(true);
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User)
            .MapToConstructor(true);
    }
}