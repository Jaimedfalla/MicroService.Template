using MicroService.Template.Transversal.Common.Constants;

namespace MicroService.Template.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services,IConfiguration configuration) {
            services.AddHealthChecks()
                .AddSqlServer(configuration[Variables.CONNECTION_STRING_NAME], tags: new[] {"database"})
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });
            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
