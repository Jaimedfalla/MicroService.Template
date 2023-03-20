using MicroService.Template.Application.Main;
using MicroService.Template.Persistence;
using MicroService.Template.Services.WebApi.Modules.Validator;
using MicroService.Template.Transversal.Mapper;

namespace MicroService.Template.Services.WebApi.Modules.Layers
{
    public static class LayersExtensions
    {
        public static IServiceCollection InitLayers(this IServiceCollection services,IConfiguration configuration) {
            services.InitApplication();
            services.InitValidators();
            services.InitMapper();
            services.InitRepositories(configuration);

            return services;
        }

        public static IServiceCollection InitMapper(this IServiceCollection services) {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            return services;
        }
    }
}
