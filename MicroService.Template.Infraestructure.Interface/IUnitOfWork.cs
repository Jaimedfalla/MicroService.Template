using System;

namespace MicroService.Template.Infraestructure.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomersRepository Customers { get; }
        IUserRepository Users { get; }
    }
}
