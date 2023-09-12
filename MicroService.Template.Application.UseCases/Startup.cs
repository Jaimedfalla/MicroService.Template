using MicroService.Template.Application.Interface.UseCases;
using MicroService.Template.Application.UseCases.Customers;
using MicroService.Template.Application.UseCases.Discounts;
using MicroService.Template.Application.UseCases.Users;
using MicroService.Template.Application.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Template.Application.UseCases
{
    public static class Startup
    {
        public static IServiceCollection InitApplication(this IServiceCollection service) {
            service.AddScoped<ICustomerApplication, CustomerApplication>();
            service.AddScoped<IUserApplication, UserApplication>();
            service.AddAutoMapper(typeof(Startup));
            service.AddScoped<IDiscountApplication, DiscountApplication>();
            service.AddTransient<UserDtoValidator>();
            service.AddTransient<DiscountDtoValidator>();

            return service;
        }
    }
}
