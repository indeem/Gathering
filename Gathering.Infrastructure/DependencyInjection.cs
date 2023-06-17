using Gathering.Application.Common.Interfaces.Authentication;
using Gathering.Application.Common.Interfaces.Services;
using Gathering.Infrastructure.Authentication;
using Gathering.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gathering.Infrastructure;

public static class DependencyInjection
{
     public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
     {
          services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
          services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
          services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
          
          return services;
     }
}