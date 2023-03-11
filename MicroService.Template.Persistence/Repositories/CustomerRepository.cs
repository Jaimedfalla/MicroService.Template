using Dapper;
using MicroService.Template.Domain.Entities;
using MicroService.Template.Persistence.Context;
using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MicroService.Template.Persistence.Repositories
{
    internal class CustomerRepository : ICustomersRepository
    {
        private readonly DapperContext _context;
        private bool _onlyId = false;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public bool Add(Customer entity)
        {
            DynamicParameters parameters = BuildParameter(entity);
            using IDbConnection con = _context.CreateConnection();
            int result = con.Execute(CustomerConstants.INSERT_COMAND, parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public async Task<bool> AddAsync(Customer entity)
        {
            DynamicParameters parameters = BuildParameter(entity);
            using IDbConnection con = _context.CreateConnection();
            int result = await con.ExecuteAsync(CustomerConstants.INSERT_COMAND, parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool Delete(string Id)
        {
            Customer customer = new Customer {
                CustomerId = Id
            };

            _onlyId = true;
            DynamicParameters parameters = BuildParameter(customer);
            using IDbConnection con = _context.CreateConnection();
            int result = con.Execute(CustomerConstants.DELETE_COMAND, parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public async Task<bool> DeleteAsync(string Id)
        {
            Customer customer = new Customer
            {
                CustomerId = Id
            };

            _onlyId = true;
            DynamicParameters parameters = BuildParameter(customer);
            using IDbConnection con = _context.CreateConnection();
            int result = await con.ExecuteAsync(CustomerConstants.DELETE_COMAND, parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public Customer GetCustomer(string Id)
        {
            Customer customer = new Customer
            {
                CustomerId = Id
            };
            _onlyId = true;
            DynamicParameters parameters = BuildParameter(customer);
            using IDbConnection con = _context.CreateConnection();
            return con.QuerySingle<Customer>(CustomerConstants.GET_BY_ID_COMAND, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<Customer> GetCustomerAsync(string Id)
        {
            Customer customer = new Customer
            {
                CustomerId = Id
            };
            _onlyId = true;
            DynamicParameters parameters = BuildParameter(customer);
            using IDbConnection con = _context.CreateConnection();
            return await con.QuerySingleAsync<Customer>(CustomerConstants.GET_BY_ID_COMAND, parameters, commandType: CommandType.StoredProcedure);
        }
        public bool Update(Customer entity)
        {
            _onlyId = false;
            DynamicParameters parameters = BuildParameter(entity);
            using IDbConnection con = _context.CreateConnection();
            int result = con.Execute(CustomerConstants.UPDATE_COMAND, parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public async Task<bool> UpdateAsync(Customer entity) {
            DynamicParameters parameters = BuildParameter(entity);
            using IDbConnection con = _context.CreateConnection();
            int result = await con.ExecuteAsync(CustomerConstants.UPDATE_COMAND, parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public IEnumerable<Customer> GetAll()
        {
            using IDbConnection con = _context.CreateConnection();
            return con.Query<Customer>(CustomerConstants.GET_ALL_COMAND, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Customer>> GetAllAsync() {
            using IDbConnection con = _context.CreateConnection();
            return await con.QueryAsync<Customer>(CustomerConstants.GET_ALL_COMAND, CommandType.StoredProcedure);
        }
        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize) {
            using IDbConnection con = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PageNumber", pageNumber);
            parameters.Add("@PageSize", pageSize);
            return con.Query<Customer>(CustomerConstants.GET_CUSTOMERS_PAGINATED, parameters, commandType: CommandType.StoredProcedure);
        }
        public int Count() {
            using IDbConnection con = _context.CreateConnection();
            string query = "SELECT COUNT(CustomerId) FROM Customers";
            return con.ExecuteScalar<int>(query, commandType: CommandType.Text);
        }
        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using IDbConnection con = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PageNumber", pageNumber);
            parameters.Add("@PageSize", pageSize);
            return await con.QueryAsync<Customer>(CustomerConstants.GET_CUSTOMERS_PAGINATED, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> CountAsync()
        {
            using IDbConnection con = _context.CreateConnection();
            string query = "SELECT COUNT(CustomerId) FROM Customers";
            return await con.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
        }

        private DynamicParameters BuildParameter(Customer customer)
        {
            if (customer is null) throw new ArgumentNullException();

            var parameter = new DynamicParameters();
            parameter.Add("@customerID", customer.CustomerId);

            if (!_onlyId)
            {
                parameter.Add("@CompanyName", customer.CompanyName);
                parameter.Add("@ContactName", customer.ContactName);
                parameter.Add("@ContactTitle", customer.ContactTitle);
                parameter.Add("@Address", customer.Address);
                parameter.Add("@City", customer.City);
                parameter.Add("@Region", customer.Region);
                parameter.Add("@PostalCode", customer.PostalCode);
                parameter.Add("@Country", customer.Country);
                parameter.Add("@Phone", customer.Phone);
                parameter.Add("@Fax", customer.Fax);
            }

            return parameter;
        }
    }
}