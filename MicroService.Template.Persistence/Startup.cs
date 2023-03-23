using Microsoft.Extensions.DependencyInjection;
using MicroService.Template.Persistence.Context;
using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Persistence.Repositories;
using MicroService.Template.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MicroService.Template.Persistence
{
    public static class Startup
    {
        public static IServiceCollection InitRepositories(this IServiceCollection service,IConfiguration configuration) {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQL_connection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
            service.AddSingleton<DapperContext>();
            service.AddScoped<AuditableEntitySaveInterceptor>();
            service.AddScoped<ICustomersRepository, CustomerRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IDiscountRepository,DiscountRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
