using Microsoft.Extensions.DependencyInjection;
using MicroService.Template.Persistence.Context;
using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Persistence.Repositories;

namespace MicroService.Template.Persistence
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
