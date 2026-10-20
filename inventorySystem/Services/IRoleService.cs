using inventorySystem.Dtos.Roles;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface IRoleService
    {
        Task<Role> Create(CreateRoleDto dto);
        Task<List<Role>> GetAllRoles();
        Task<Role> DeleteRole(string roleName);
    }
}
