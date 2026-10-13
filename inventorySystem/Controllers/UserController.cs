using inventorySystem.Dtos.Users;
using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            try
            {
                var user = await _userService.CreateUser(dto);

                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
