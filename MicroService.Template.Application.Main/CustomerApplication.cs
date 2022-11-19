using AutoMapper;
using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface;
using MicroService.Template.Domain.Entities;
using MicroService.Template.Domain.Interface;
using MicroService.Template.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using MicroService.Template.Transversal.Common.Constants;

namespace MicroService.Template.Application.Main
{
    internal class CustomerApplication:ICustomerApplication
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDomain _customerDomain;
        private readonly IAppLogger<CustomerApplication> _logger;

        public CustomerApplication(IMapper mapper, ICustomerDomain customerDomain,IAppLogger<CustomerApplication> logger)
        {
            _mapper = mapper;
            _customerDomain = customerDomain;
            _logger = logger;
        }

        public Response<bool> Add(CustomerDTO customerDto)
        {
            Response<bool> response = new Response<bool>();
            try {
                Customer customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customerDomain.Add(customer);
                response.IsSuccess = true;
                response.Message = string.Format(Messages.SUCCESS,nameof(Add));
            }
            catch(Exception ex) {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> AddAsync(CustomerDTO customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.AddAsync(customer);
                response.IsSuccess = true;
                response.Message = string.Format(Messages.SUCCESS, nameof(Add));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                response.IsSuccess = true;
                response.Message = string.Format(Messages.SUCCESS, $"{nameof(Delete)}ed");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                response.IsSuccess = true;
                response.Message = string.Format(Messages.SUCCESS, $"{nameof(Delete)}ed");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            Response<IEnumerable<CustomerDTO>> response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                response.IsSuccess = response.Data.Any();
                response.Message = Messages.RETRIEVED;

                _logger.LogInformation(Messages.RETRIEVED);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }
        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            Response<IEnumerable<CustomerDTO>> response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                response.IsSuccess = response.Data.Any();
                response.Message = Messages.RETRIEVED;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int numberPage, int pageSize)
        {
            var data = _customerDomain.GetAllWithPagination(numberPage, pageSize);
            return PaginateData(data,numberPage,pageSize);
        }
            
        public async Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int numberPage, int pageSize)
        {
            var data = await _customerDomain.GetAllWithPaginationAsync(numberPage, pageSize);
            return PaginateData(data, numberPage, pageSize);
        }
        public Response<CustomerDTO> GetCustomer(string customerId)
        {
            Response<CustomerDTO> response = new Response<CustomerDTO>();
            try
            {
                var customers = _customerDomain.GetCustomer(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customers);
                response.IsSuccess = response.Data !=null;
                response.Message = Messages.RETRIEVED;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<CustomerDTO>> GetCustomerAsync(string customerId)
        {
            Response<CustomerDTO> response = new Response<CustomerDTO>();
            try
            {
                var customers = await _customerDomain.GetCustomerAsync(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customers);
                response.IsSuccess = response.Data != null;
                response.Message = Messages.RETRIEVED;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<bool> Update(CustomerDTO customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customerDomain.Update(customer);
                response.IsSuccess = true;
                response.Message = string.Format(Messages.SUCCESS, $"{nameof(Update)}ed");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDto)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.UpdateAsync(customer);
                response.IsSuccess = true;
                response.Message = string.Format(Messages.SUCCESS, $"{nameof(Update)}ed");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        private ResponsePagination<IEnumerable<CustomerDTO>> PaginateData(IEnumerable<Customer> customers, int numberPage, int pageSize) {
            ResponsePagination<IEnumerable<CustomerDTO>> response = new ResponsePagination<IEnumerable<CustomerDTO>>();
            try
            {
                int count = _customerDomain.Count();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                if (response.Data != null)
                {
                    response.PageNumber = numberPage;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
