using FluentValidation;
using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Validator;

namespace MicroService.Template.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection InitValidators(this IServiceCollection service) {
            service.AddTransient<IValidator<UserLoginDto>, UserDtoValidator>();

            return service;
        }
    }
}
