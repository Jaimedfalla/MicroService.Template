using Microsoft.Extensions.Diagnostics.HealthChecks;
using MicroService.Template.Transversal.Common.Constants;

namespace MicroService.Template.Services.WebApi.Modules.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly Random _random = new();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //HERE: Put the code to check other external service. This is an example to simulate a response time

            var responseTime = _random.Next(1, 300);
            var response = responseTime switch
            {
                < 100 => HealthCheckResult.Healthy(Messages.HEALTY_STATUS),
                < 200 => HealthCheckResult.Degraded(Messages.DEGRADED_STATUS),
                _ => HealthCheckResult.Unhealthy(Messages.UNHEALTY_STATUS),
            };

            return Task.FromResult(response);
        }
    }
}
