using MicroService.Template.Domain.Entities;
using MicroService.Template.Domain.Interface;
using MicroService.Template.Infraestructure.Interface;

namespace MicroService.Template.Domain.Core
{
    internal class UserDomain : IUserDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string userName, string password) => _unitOfWork.Users.Authenticate(userName, password);
    }
}
