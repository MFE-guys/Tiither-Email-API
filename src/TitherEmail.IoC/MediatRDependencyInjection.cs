using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TitherEmail.Domain.Handlers;
using TitherEmail.Shared.Requests;
using TitherEmail.Shared.ViewModels;

namespace TitherEmail.IoC
{
    public static class MediatRDependencyInjection
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            var assemblies = new[] { 
                typeof(SendEmailRequest).GetTypeInfo().Assembly, 
                typeof(SendEmailRequestHandlercs).GetTypeInfo().Assembly };

            services.AddMediatR(assemblies);

            // TODO: Add pipelines Behavior
        }
    }
}