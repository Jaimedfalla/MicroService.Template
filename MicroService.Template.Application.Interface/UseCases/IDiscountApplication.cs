using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MicroService.Template.Application.DTO;
using MicroService.Template.Transversal.Common;

namespace MicroService.Template.Application.Interface.UseCases;

public interface IDiscountApplication
{
    Task<Response<bool>> CreateAsync(DiscountDto discountDto,CancellationToken cancellationToken = default);
    Task<Response<bool>> UpdateAsync(DiscountDto discountDto,CancellationToken cancellationToken = default);
    Task<Response<bool>> DeleteAsync(int id,CancellationToken cancellationToken = default);
    Task<Response<DiscountDto>> GetAsync(int id,CancellationToken cancellationToken = default);
    Task<Response<List<DiscountDto>>> GetAllAsync(CancellationToken cancellationToken = default);
}