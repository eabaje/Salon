using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Salon.Application.Extensions
{
    //public static class MediatRExtensions
    //{
    //    public static IServiceCollection AddMediatR(this IServiceCollection services, params Assembly[] handlerAssemblies)
    //    {
    //        services.AddTransient<IMediator>(x => new Mediator(x.GetService<SingleInstanceFactory>(), x.GetService<MultiInstanceFactory>()));
    //        services.AddTransient<SingleInstanceFactory>(x => t => x.GetRequiredService(t));
    //        services.AddTransient<MultiInstanceFactory>(x => t => x.GetServices(t));

    //        foreach (var assembly in handlerAssemblies)
    //        {
    //            foreach (var type in assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract))
    //            {
    //                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo()).ToArray();

    //                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncRequestHandler<,>)))
    //                {
    //                    services.AddTransient(handlerType.AsType(), type.AsType());
    //                }

    //                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)))
    //                {
    //                    services.AddTransient(handlerType.AsType(), type.AsType());
    //                }

    //                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
    //                {
    //                    services.AddTransient(handlerType.AsType(), type.AsType());
    //                }
    //            }
    //        }

    //        return services;
    //    }
    //}
}

