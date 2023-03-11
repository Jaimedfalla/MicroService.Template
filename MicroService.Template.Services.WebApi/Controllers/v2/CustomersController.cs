using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface.UseCases;
using MicroService.Template.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.Template.Services.WebApi.Controllers.v2
{

    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerApplication _service;

        public CustomersController(ICustomerApplication service)
        {
            _service = service;
        }
        /// <summary>
        /// Updates a customer by synchronous way
        /// </summary>
        /// <param name="customer">Customer data to update</param>
        /// <returns>Customer was updated</returns>
        [HttpPut("Update/{customerId}")]
        public IActionResult Update(string customerId, [FromBody] CustomerDTO customerDto)
        {
            var customer = _service.GetCustomer(customerId);

            if (customer?.Data is null) return NotFound(customer?.Message);
            if (customer is null) return BadRequest();

            Response<bool> result = _service.Update(customerDto);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Insert a new customer
        /// </summary>
        /// <param name="customer">New customer data</param>
        /// <returns>Resulto of the process</returns>
        [HttpPost]
        public IActionResult Insert([FromBody] CustomerDTO customer)
        {
            if (customer is null) return BadRequest();

            Response<bool> result = _service.Add(customer);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            Response<bool> result = _service.Delete(customerId);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            Response<CustomerDTO> result = _service.GetCustomer(customerId);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]int numberPage,int pageSize)
        {
            ResponsePagination<IEnumerable<CustomerDTO>> result = _service.GetAllWithPagination(numberPage, pageSize);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("Async")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDTO customer)
        {
            if (customer is null) return BadRequest();

            Response<bool> result = await _service.AddAsync(customer);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpDelete("{customerId}/async")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            Response<bool> result = await _service.DeleteAsync(customerId);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("{customerId}/async")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            Response<CustomerDTO> result = await _service.GetCustomerAsync(customerId);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("Async")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int numberPage, int pageSize)
        {
            ResponsePagination<IEnumerable<CustomerDTO>> result = await _service.GetAllWithPaginationAsync(numberPage, pageSize);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPut("UpdateAsync/{customerId}")]
        public async Task<IActionResult> UpdateAsync(string customerId, [FromBody] CustomerDTO customerDto)
        {
            var customer = await _service.GetCustomerAsync(customerId);

            if (customer?.Data is null) return NotFound(customer?.Message);
            if (customer is null) return BadRequest();

            Response<bool> result = await _service.UpdateAsync(customerDto);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result.Message);
        }
    }
}
