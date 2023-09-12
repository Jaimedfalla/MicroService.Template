using AutoMapper;
using MicroService.Template.Domain.Entities;
using MicroService.Template.Application.DTO;

namespace MicroService.Template.Application.UseCases.Common.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
        }
    }
}
