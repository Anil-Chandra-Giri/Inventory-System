using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;
using static inventorySystem.Dtos.Auth.AuthDto;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _svc;

        public AuthController(IAuthService svc) => _svc = svc;

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
        {
            try
            {
                return Ok(await _svc.Login(dto));
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
