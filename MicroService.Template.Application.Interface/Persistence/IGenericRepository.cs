using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.Template.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(string Id);
        T GetCustomer(string Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();

        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string Id);
        Task<T> GetCustomerAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
    }
}
