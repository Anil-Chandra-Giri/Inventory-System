using inventorySystem.Dtos.Users;
using inventorySystem.Model;
using inventorySystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
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

        [HttpPut("Update")]
        public async Task<ActionResult<UserDto>> Update(string UserName, UpdateUserDto dto)
        {
            var updated = await _userService.UpdateUser(UserName, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpPost("ChangeRole")]
        public async Task<ActionResult<UserDto>> ChangeRole(string UserName, ChangeRoleDto dto)
        {
            try
            {
                var updated = await _userService.ChangeRole(UserName, dto);
                return updated is null ? NotFound() : Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
           return Ok(await _userService.GetAllUser());
        }


        [HttpGet("GetByUsername")]
        public async Task<ActionResult<User>> GetUser(string UserName)
        {
            var user = await _userService.GetUser(UserName);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            try
            {
                var user = await _userService.DeleteUser(userName);

                return Ok(new
                {
                    message = "User deactivated successfully.",
                    user = new { user.UserName, user.IsActive }
                });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
