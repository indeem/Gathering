using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Gathering.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Gathering.Application;

public static class DependencyInjection
{
     public static IServiceCollection AddApplication(this IServiceCollection services)
     {
          services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
          
          services.AddScoped(typeof(IPipelineBehavior<,>), 
               typeof(ValidationBehaviour<,>));
          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          
          return services;
     }
}