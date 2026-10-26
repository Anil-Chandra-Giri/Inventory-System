using inventorySystem.Dtos.Users;
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

        [HttpPost("temp-create-admin")]
        public async Task<IActionResult> TempCreateAdmin([FromServices] IUserService userService)
        {
            try
            {
                var dto = new CreateUserDto
                {
                    FullName = "System Admin",
                    Email = "admin@test.com",
                    UserName = "admin",
                    Password = "Admin@123",
                    RoleName = "Admin"
                };

                var user = await userService.CreateUser(dto);
                return Ok("Admin created successfully! You can log in now.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
