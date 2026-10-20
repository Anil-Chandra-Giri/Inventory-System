using inventorySystem.Dtos.Roles;
using inventorySystem.Model;
using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly IRoleService _svc;

        public RolesController(IRoleService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Create(CreateRoleDto dto)
        {
            var created = await _svc.Create(dto);
            return Ok("Role created");
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            return Ok(await _svc.GetAllRoles());
        }


        [HttpDelete("DeleteRole")]
        public async Task<ActionResult> DeleteRole(string roleName)
        {
            return Ok(await _svc.DeleteRole(roleName));
        }
    }
}
