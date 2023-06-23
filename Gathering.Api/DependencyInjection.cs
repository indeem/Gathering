using Gathering.Api.Common.Errors;
using Gathering.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Gathering.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddSingleton<ProblemDetailsFactory, GatheringProblemDetailsFactory>();

        services.AddMapping();
        
        return services;
    }
}