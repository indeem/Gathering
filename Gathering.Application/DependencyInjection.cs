using System.Reflection;
using ErrorOr;
using FluentValidation;
using Gathering.Application.Common.Behaviours;
using Gathering.Application.Generic.Common;
using Gathering.Application.Generic.Queries.GetQuery;
using Gathering.Domain.Test;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Gathering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly); });

        services.AddTransient<IRequestHandler<GetQuery, ErrorOr<List<GetResult>>>, GetQueryHandler<Test>>();

        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));

        //Ggf. mit Pipeline behavior das Get aufrufen

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMapping();

        return services;
    }


    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}