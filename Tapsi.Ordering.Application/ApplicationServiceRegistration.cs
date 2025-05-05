using System.Reflection;
using AutoMapper;
using Tapsi.Ordering.Application.Behaviours;
using Tapsi.Ordering.Application.Common;
using Tapsi.Ordering.Application.ExceptionHandler;
using Tapsi.Ordering.Application.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Tapsi.Ordering.Application.Features.Ordering.GetOrders;

namespace Tapsi.Ordering.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(Logging));
        services.AddValidatorsFromAssemblyContaining<GetOrdersValidator>();
        services.AddScoped<ApiResponseException>();
        services.AddScoped(provider =>
          new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); }).CreateMapper());
        return services;
    }
}