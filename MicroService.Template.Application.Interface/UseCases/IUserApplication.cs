using MicroService.Template.Application.DTO;
using MicroService.Template.Transversal.Common;

namespace MicroService.Template.Application.Interface.UseCases
{
    public interface IUserApplication
    {
        Response<UserDto> Authenticate(UserLoginDto userLogin);
    }
}
