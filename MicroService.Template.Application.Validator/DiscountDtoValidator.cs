using FluentValidation;
using MicroService.Template.Application.DTO;

namespace MicroService.Template.Application.Validator;

public class DiscountDtoValidator : AbstractValidator<DiscountDto>
{
    DiscountDtoValidator(){
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Description).NotNull().NotEmpty();
        RuleFor(x => x.Percent).NotNull().NotEmpty().GreaterThan(0);
    }
}