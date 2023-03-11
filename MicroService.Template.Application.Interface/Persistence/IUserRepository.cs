using MicroService.Template.Domain.Entities;

namespace MicroService.Template.Application.Interface.Persistence 
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}
