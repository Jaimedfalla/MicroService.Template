using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface;
using MicroService.Template.Domain.Interface;
using MicroService.Template.Transversal.Common;
using System;
using MicroService.Template.Transversal.Common.Constants;

namespace MicroService.Template.Application.Main
{
    internal class UserApplication:IUserApplication
    {
        private readonly IUserDomain _domain;
        private readonly IMapper _mapper;
        private readonly IValidator<UserLoginDto> _validator;

        public UserApplication(IUserDomain domain, IMapper mapper, IValidator<UserLoginDto> validator)
        {
            _domain = domain;
            _mapper = mapper;
            _validator = validator;
        }

        public Response<UserDTO> Authenticate(UserLoginDto userLogin)
        {
            Response<UserDTO> response = new Response<UserDTO>();
            ValidationResult result = _validator.Validate(userLogin);

            if (!result.IsValid) {
                response.Message = Messages.VALIDATION_ERRORS;
                response.Errors = result.Errors;
                return response;
            }

            try
            {
                var user = _domain.Authenticate(userLogin.UserName, userLogin.Password);
                response.Data = _mapper.Map<UserDTO>(user);
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
