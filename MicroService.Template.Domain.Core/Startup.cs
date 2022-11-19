using MicroService.Template.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Template.Domain.Core
{
    public static class Startup
    {
        public static IServiceCollection InitDomain(this IServiceCollection service) {
            service.AddScoped<ICustomerDomain, CustomerDomain>();
            service.AddScoped<IUserDomain, UserDomain>();

            return service;
        }
    }
}
