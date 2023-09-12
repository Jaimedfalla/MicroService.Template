using MicroService.Template.Application.DTO;
using MicroService.Template.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.Template.Application.Interface.UseCases
{
    public interface ICustomerApplication
    {
        Response<bool> Add(CustomerDto customer);
        Response<bool> Update(CustomerDto customer);
        Response<bool> Delete(string customerId);
        Response<CustomerDto> GetCustomer(string customerId);
        Response<IEnumerable<CustomerDto>> GetAll();
        ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int numberPage,int pageSize);

        Task<Response<bool>> AddAsync(CustomerDto customer);
        Task<Response<bool>> UpdateAsync(CustomerDto customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDto>> GetCustomerAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int numberPage, int pageSize);
    }
}
