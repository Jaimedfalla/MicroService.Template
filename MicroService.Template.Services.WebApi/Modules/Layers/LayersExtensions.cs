using MicroService.Template.Application.Main;
using MicroService.Template.Domain.Core;
using MicroService.Template.Infraestructure.Repositories;
using MicroService.Template.Services.WebApi.Modules.Validator;
using MicroService.Template.Transversal.Mapper;

namespace MicroService.Template.Services.WebApi.Modules.Layers
{
    public static class LayersExtensions
    {
        public static IServiceCollection InitLayers(this IServiceCollection services) {
            services.InitValidators();
            services.InitMapper();
            services.InitApplication();
            services.InitDomain();
            services.InitRepositories();

            return services;
        }

        public static IServiceCollection InitMapper(this IServiceCollection services) {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            return services;
        }
    }
}
