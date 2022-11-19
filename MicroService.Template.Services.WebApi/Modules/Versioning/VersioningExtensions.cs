using Microsoft.AspNetCore.Mvc.Versioning;

namespace MicroService.Template.Services.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection service) {
            service.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";//semantic versioning major.minor.patch
                /*
                 * To read api version from url must be in true
                 */
                setup.SubstituteApiVersionInUrl = true;
            });

            service.AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true; //Shows to the customers all available versions
                /*
                 * To read api version on request from query string parameter api-version -> options.ApiVersionReader = new QueryStringApiVersionReader("api-version")
                 * To read api version on request header from x-version -> options.ApiVersionReader = new HeaderApiVersionReader("x-version");
                 * To read api version from url -> options.ApiVersionReader = new UrlSegmentApiVersionReader();
                 */
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            return service;
        }
    }
}
