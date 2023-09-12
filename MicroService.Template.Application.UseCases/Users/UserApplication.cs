using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface.UseCases;
using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Transversal.Common;
using System;
using MicroService.Template.Transversal.Common.Constants;

namespace MicroService.Template.Application.UseCases.Users
{
    internal class UserApplication:IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UserLoginDto> _validator;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserLoginDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public Response<UserDto> Authenticate(UserLoginDto userLogin)
        {
            Response<UserDto> response = new Response<UserDto>();
            ValidationResult result = _validator.Validate(userLogin);

            if (!result.IsValid) {
                response.Message = Messages.VALIDATION_ERRORS;
                response.Errors = result.Errors;
                return response;
            }

            try
            {
                var user = _unitOfWork.Users.Authenticate(userLogin.UserName, userLogin.Password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = Messages.AUTHENTICATED;
            }
            catch (InvalidOperationException) {
                response.IsSuccess = true;
                response.Message = Messages.USER_NOT_EXISTS;
            }
            catch(Exception ex) {
                response.Message = ex.Message;
                throw;
            }

            return response;
        }
    }
}
