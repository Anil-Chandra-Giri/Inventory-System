using inventorySystem.Dtos.Roles;
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

    }
}
