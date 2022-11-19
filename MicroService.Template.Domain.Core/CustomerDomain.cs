using MicroService.Template.Domain.Entities;
using MicroService.Template.Domain.Interface;
using MicroService.Template.Infraestructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.Template.Domain.Core
{
    internal class CustomerDomain :ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(Customer customer) => _unitOfWork.Customers.Add(customer);
        public async Task<bool> AddAsync(Customer customer) => await _unitOfWork.Customers.AddAsync(customer);

        public int Count() => _unitOfWork.Customers.Count();
        public async Task<int> CountAsync() => await _unitOfWork.Customers.CountAsync();
        public bool Delete(string customerId) => _unitOfWork.Customers.Delete(customerId);
        public async Task<bool> DeleteAsync(string customerId) => await _unitOfWork.Customers.DeleteAsync(customerId);
        public IEnumerable<Customer> GetAll() => _unitOfWork.Customers.GetAll();
        public async Task<IEnumerable<Customer>> GetAllAsync() => await _unitOfWork.Customers.GetAllAsync();
        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize) => _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize) 
            => await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
        public Customer GetCustomer(string customerId) => _unitOfWork.Customers.GetCustomer(customerId);
        public async Task<Customer> GetCustomerAsync(string customerId) => await _unitOfWork.Customers.GetCustomerAsync(customerId);
        public bool Update(Customer customer) => _unitOfWork.Customers.Update(customer);
        public async Task<bool> UpdateAsync(Customer customer) => await _unitOfWork.Customers.UpdateAsync(customer);
    }
}
