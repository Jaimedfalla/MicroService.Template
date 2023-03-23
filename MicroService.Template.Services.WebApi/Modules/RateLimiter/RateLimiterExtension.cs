using MicroService.Template.Transversal.Common.Constants;
using Microsoft.AspNetCore.RateLimiting;

namespace MicroService.Template.Services.WebApi.Modules.RateLimiter
{
    public static class RateLimiterExtension
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddRateLimiter(options =>
            {
                //Allows 4 requests for each 30 seconds window of time
                options.AddFixedWindowLimiter(policyName: Variables.RATE_LIMITING_POLICY, fixedWindow => {
                    fixedWindow.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]); //Maximum number requests
                    fixedWindow.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]));
                    fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    fixedWindow.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]);
                });

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });

            return service;
        }
    }
}
