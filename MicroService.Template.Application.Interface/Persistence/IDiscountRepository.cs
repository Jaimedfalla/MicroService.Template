using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MicroService.Template.Domain.Entities;

namespace MicroService.Template.Application.Interface.Persistence
{
    public interface IDiscountRepository:IGenericRepository<Discount>
    {
        Task<Discount> GetAsync(int id, CancellationToken cancellationToken);
        
        Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken);
    }
}