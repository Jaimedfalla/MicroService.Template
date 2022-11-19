using MicroService.Template.Infraestructure.Interface;
using System;

namespace MicroService.Template.Infraestructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(ICustomersRepository customers,IUserRepository users)
        {
            Customers = customers;
            Users = users;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
