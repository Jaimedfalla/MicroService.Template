using Dapper;
using MicroService.Template.Domain.Entities;
using MicroService.Template.Infraestructure.Data;
using MicroService.Template.Infraestructure.Interface;
using System.Data;

namespace MicroService.Template.Infraestructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public Users Authenticate(string userName, string password)
        {
            using var connection = _context.CreateConnection();
            string query = "UsersGetByUserAndPassword";
            var parameters = new
            {
                UserName = userName,
                Password = password
            };

            var user = connection.QuerySingle<Users>(query, parameters,commandType: CommandType.StoredProcedure);

            return user;
        }
    }
}
