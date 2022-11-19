using MicroService.Template.Application.DTO;
using MicroService.Template.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.Template.Application.Interface
{
    public interface ICustomerApplication
    {
        Response<bool> Add(CustomerDTO customer);
        Response<bool> Update(CustomerDTO customer);
        Response<bool> Delete(string customerId);
        Response<CustomerDTO> GetCustomer(string customerId);
        Response<IEnumerable<CustomerDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int numberPage,int pageSize);

        Task<Response<bool>> AddAsync(CustomerDTO customer);
        Task<Response<bool>> UpdateAsync(CustomerDTO customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDTO>> GetCustomerAsync(string customerId);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int numberPage, int pageSize);
    }
}
