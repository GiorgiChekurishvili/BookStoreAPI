using BookStore.DTOs;
using BookStore.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterDTO>> Register(UserRegisterDTO userRegisterDTO)
        {
            var data = await _authService.Register(userRegisterDTO);
            if (data == null)
            {
                return BadRequest("This email is already registered");
            }
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> Login(UserLoginDTO userLoginDTO)
        {
            var data = await _authService.Login(userLoginDTO);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
