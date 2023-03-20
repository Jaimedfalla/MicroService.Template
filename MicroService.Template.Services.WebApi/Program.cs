using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MicroService.Template.Services.WebApi.Modules.Authentication;
using MicroService.Template.Services.WebApi.Modules.Feature;
using MicroService.Template.Services.WebApi.Modules.HealthCheck;
using MicroService.Template.Services.WebApi.Modules.Layers;
using MicroService.Template.Services.WebApi.Modules.Swagger;
using MicroService.Template.Services.WebApi.Modules.Versioning;
using MicroService.Template.Services.WebApi.Modules.Watch;
using MicroService.Template.Transversal.Common;
using MicroService.Template.Transversal.Logging;
using WatchDog;

string myPolicy = "apiECommercePolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFeature(builder.Configuration, myPolicy);
builder.Services.AddControllers();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.InitLayers(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddScoped(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseApiVersioning();
app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors(myPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseWatchDog(conf => {
    conf.WatchPageUsername = builder.Configuration["WatchDog:UserName"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:Password"];
});

app.Run();
public partial class Program { };