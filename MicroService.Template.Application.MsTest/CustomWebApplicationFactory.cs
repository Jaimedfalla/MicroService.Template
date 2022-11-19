using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace MicroService.Template.Application.MsTest
{
    public class CustomWebApplicationFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => {
                var integrationBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .AddEnvironmentVariables().Build();

                config.AddConfiguration(integrationBuilder);
            });
        }
    }
}
