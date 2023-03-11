using MicroService.Template.Application.Interface.UseCases;
using Microsoft.Extensions.DependencyInjection;
using MicroService.Template.Application.Main.Customers;
using MicroService.Template.Application.Main.Users;

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
