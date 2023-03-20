using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Persistence.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Template.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationContext;
        
        public ICustomersRepository Customers { get; }

        public IUserRepository Users { get; }

        public IDiscountRepository Discounts {get;}

        public UnitOfWork(ICustomersRepository customers
            ,IUserRepository users
            ,IDiscountRepository discountRepository
            ,ApplicationDbContext context
        )
        {
            Customers = customers;
            Users = users;
            Discounts = discountRepository;
            _applicationContext = context;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.SaveChangesAsync(cancellationToken);
        }
    }
}
