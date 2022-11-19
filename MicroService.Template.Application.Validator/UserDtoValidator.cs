using FluentValidation;
using MicroService.Template.Application.DTO;

namespace MicroService.Template.Application.Validator
{
    public class UserDtoValidator:AbstractValidator<UserLoginDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u=>u.Password).NotNull().NotEmpty();
        }
    }
}
