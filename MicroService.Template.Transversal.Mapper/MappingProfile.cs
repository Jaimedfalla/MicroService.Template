using AutoMapper;
using MicroService.Template.Domain.Entities;
using MicroService.Template.Application.DTO;

namespace MicroService.Template.Transversal.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Users, UserDTO>().ReverseMap();
        }
    }
}
