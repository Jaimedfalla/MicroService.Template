using System.Text.Json.Serialization;

namespace MicroService.Template.Services.WebApi.Modules.Feature
{
    /// <summary>
    /// Feature Extensions
    /// </summary>
    public static class FeatureExtensions
    {
        /// <summary>
        /// Add Feature
        /// </summary>
        /// <param name="service">Service Collection</param>
        /// <param name="configuration">Configuration</param>
        /// <param name="myPolicy">CORS Policy</param>
        /// <returns></returns>
        public static IServiceCollection AddFeature(this IServiceCollection service, IConfiguration configuration,string myPolicy) {
            service.AddCors(options => {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy.WithOrigins(configuration["Config:OriginCors"])
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            service.AddControllers().AddJsonOptions(opts => {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            return service;
        }
    }
}
