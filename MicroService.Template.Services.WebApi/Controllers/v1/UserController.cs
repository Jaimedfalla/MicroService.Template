using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface.UseCases;
using MicroService.Template.Services.WebApi.Helpers;
using MicroService.Template.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroService.Template.Services.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0",Deprecated = true)]
    public class UserController : Controller
    {
        private readonly IUserApplication _application;
        private readonly AppSettings _appSettings;

        public UserController(IUserApplication application, IOptions<AppSettings> appSettings)
        {
            _application = application;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Authenticates an user
        /// </summary>
        /// <param name="user">User data</param>
        /// <returns>Token JWT</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserLoginDto user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)));
            }

            var response = _application.Authenticate(user);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }

            return BadRequest(response);
        }

        private string BuildToken(Response<UserDTO> user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                //Permite especificar las credenciales con las cuales se va a firmar el token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
