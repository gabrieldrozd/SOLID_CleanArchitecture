using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Gets all places where AutoMapper(Profile) is used - BETTER OPTION
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}