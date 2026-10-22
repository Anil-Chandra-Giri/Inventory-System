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

           var alreadyexists = await _db.Roles.FirstOrDefaultAsync(e=> e.RoleName == dto.RoleName);
            if (alreadyexists != null)
            {
                throw new InvalidOperationException("Role already exists");
            }

          var role = new Role
            {
                RoleCode = generator,
                RoleName = dto.RoleName.Trim(),
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
                IsActive = true,
            };

            _db.Roles.Add(role);
            await _db.SaveChangesAsync();

            return role;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _db.Roles.Where(r => r.IsActive).Select(r => new Role
            {
                RoleCode = r.RoleCode,
                RoleName = r.RoleName,
                CreatedOn = r.CreatedOn,
                LastUpdatedOn = r.LastUpdatedOn,
                IsActive = r.IsActive,
            }).ToListAsync();

        }

        public async Task<Role> DeleteRole(string RoleName)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(e=> e.RoleName== RoleName);
            if (role == null)
            {
                throw new InvalidOperationException("Role not found");
            }

            role.IsActive = false;
            role.LastUpdatedOn = DateTime.Now;

            await _db.SaveChangesAsync();
            return role;
        }
    }
}
