using MicroService.Template.Application.UseCases;
using MicroService.Template.Persistence;

namespace MicroService.Template.Services.WebApi.Modules.Layers
{
    /// <summary>
    /// Generates dependency injection for layers
    /// </summary>
    public static class LayersExtensions
    {
        /// <summary>
        /// Initializes the layers
        /// </summary>
        public static IServiceCollection InitLayers(this IServiceCollection services,IConfiguration configuration) {
            services.InitApplication();
            services.InitRepositories(configuration);

            return services;
        }
    }
}
