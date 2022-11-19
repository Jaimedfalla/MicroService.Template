using Microsoft.Extensions.Configuration;
using MicroService.Template.Transversal.Common.Constants;
using System.Data;
using System.Data.SqlClient;

namespace MicroService.Template.Infraestructure.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString(Variables.CONNECTION_STRING_NAME);
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
