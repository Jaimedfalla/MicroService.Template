using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Template.Application.Interface.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomersRepository Customers { get; }
            
        IUserRepository Users { get; }

        IDiscountRepository Discounts{get;}

        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
