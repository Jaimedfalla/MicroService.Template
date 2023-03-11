using Microsoft.Extensions.DependencyInjection;
using MicroService.Template.Persistence.Data;
using MicroService.Template.Application.Interface.Persistence;

namespace MicroService.Template.Persistence.Repositories
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
