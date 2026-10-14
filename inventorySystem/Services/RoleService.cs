using inventorySystem.Data;
using inventorySystem.Dtos.Roles;
using inventorySystem.Model;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _db;

        public RoleService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Role> Create(CreateRoleDto dto)
        {
           int count = await _db.Roles.CountAsync();
           string generator = $"R{(count+1):D2}";

          var role = new Role
            {
                RoleID = generator,
                RoleName = dto.RoleName.Trim()
            };

            _db.Roles.Add(role);
            await _db.SaveChangesAsync();

            return role;
        }

    }
}
