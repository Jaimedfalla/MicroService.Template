using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MicroService.Template.Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions: IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;   
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description) {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Api REST Architecture template",
                Description = "A template architecture to buidl an Api REST service",
                Contact = new OpenApiContact
                {
                    Email = "jaimedfalla@yahoo.com.ar"
                }
            };

            if (description.IsDeprecated) {
                info.Description += "Version deprecated";
            }

            return info;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions) {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }
    }
}
