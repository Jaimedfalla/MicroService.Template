namespace MicroService.Template.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection service, IConfiguration configuration,string myPolicy) {
            service.AddCors(options => {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy.WithOrigins(configuration["Config:OriginCors"])
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            return service;
        }
    }
}
