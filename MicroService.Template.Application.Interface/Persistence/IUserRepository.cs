using MicroService.Template.Domain.Entities;

namespace MicroService.Template.Application.Interface.Persistence 
{
    public interface IUserRepository
    {
        Users Authenticate(string userName, string password);
    }
}
