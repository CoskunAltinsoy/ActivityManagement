using ActivityManagement.Application.Dtos;
using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
           _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            return Ok();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            _authService.Login(userForLoginDto);
            return Ok();
        }
    }
}
