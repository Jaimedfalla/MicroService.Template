using MicroService.Template.Domain.Entities;

namespace MicroService.Template.Infraestructure.Interface
{
    public interface IUserRepository
    {
        Users Authenticate(string userName, string password);
    }
}
