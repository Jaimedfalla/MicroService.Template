using MicroService.Template.Domain.Entities;

namespace MicroService.Template.Domain.Interface
{
    public interface IUserDomain
    {
        Users Authenticate(string userName, string password);
    }
}
