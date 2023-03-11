using System;

namespace MicroService.Template.Application.Interface.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomersRepository Customers { get; }
        IUserRepository Users { get; }
    }
}
