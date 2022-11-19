using MicroService.Template.Application.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Template.Application.Main
{
    public static class Startup
    {
        public static IServiceCollection InitApplication(this IServiceCollection service) {
            service.AddScoped<ICustomerApplication, CustomerApplication>();
            service.AddScoped<IUserApplication, UserApplication>();

            return service;
        }
    }
}
