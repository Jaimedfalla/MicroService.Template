using Microsoft.Extensions.DependencyInjection;
using MicroService.Template.Infraestructure.Data;
using MicroService.Template.Infraestructure.Interface;

namespace MicroService.Template.Infraestructure.Repositories
{
    public static class Startup
    {
        public static IServiceCollection InitRepositories(this IServiceCollection service) {
            service.AddSingleton<DapperContext>();
            service.AddScoped<ICustomersRepository, CustomerRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
