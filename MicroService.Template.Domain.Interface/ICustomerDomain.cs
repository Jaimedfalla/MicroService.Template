using MicroService.Template.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.Template.Domain.Interface
{
    //Defines the contract to manage Business Logic for Customers
    public interface ICustomerDomain
    {
        /// <summary>
        /// Validates and insert a new customer
        /// </summary>
        /// <param name="customer">Customer to add</param>
        /// <returns>Added=1, No added = 0</returns>
        bool Add(Customer customer);

        /// <summary>
        /// Validates and existing customer in data and update it
        /// </summary>
        /// <param name="customer">Customer to update</param>
        /// <returns>Updated=1, No updated = 0</returns>
        bool Update(Customer customer);

        /// <summary>
        /// Defines business logic to delete a customer
        /// </summary>
        /// <param name="customerId">Customer id to delete</param>
        /// <returns>Deleted=1, No deleted = 0</returns>
        bool Delete(string customerId);

        /// <summary>
        /// Retrieves a customer by its id
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <returns>Customer existing</returns>
        Customer GetCustomer(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAll();

        IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();

        Task<bool> AddAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customer> GetCustomerAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();

    }
}
