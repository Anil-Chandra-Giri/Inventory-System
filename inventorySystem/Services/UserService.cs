using inventorySystem.Data;
using inventorySystem.Dtos.Users;
using inventorySystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace inventorySystem.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IPasswordHasher<User> _hasher;
        public UserService(AppDbContext db, IPasswordHasher<User> hasher)
        {
            _db = db;
            _hasher = hasher;
        }

        public async Task<User> CreateUser(CreateUserDto dto)
        {
            var existingUser = await _db.Users.FirstOrDefaultAsync(s => s.UserName == dto.UserName);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists");
            }

            var existingEmail = await _db.Users.FirstOrDefaultAsync(s => s.Email == dto.Email);
            if (existingEmail != null)
            {
                throw new InvalidOperationException("Username already exists");
            }

            var Role = await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == dto.RoleName);
            if (Role == null)
            {
                throw new InvalidOperationException("Role does not exist");
            }

            var User = new User
            {
                UserID = Guid.NewGuid().ToString(),
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.UserName,
                RoleID = Role.RoleID,
            };
            User.PasswordHash = _hasher.HashPassword(User, dto.Password);
            _db.Users.Add(User);
            await _db.SaveChangesAsync();

            return User;
        }

        public async Task<User> UpdateUser(string UserName, UpdateUserDto dto)
        {
            var user = await _db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == UserName);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User> ChangeRole(string UserName, ChangeRoleDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u=>u.UserName==UserName);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var role = await _db.Roles.FindAsync(dto.RoleID);
            if (role == null)
            {
                throw new InvalidOperationException("Role does not exist.");
            }

            user.RoleID = dto.RoleID;
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _db.Users.Select
            (u => new User
            {
                UserID = u.UserID,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                RoleID = u.RoleID,
            }
            ).OrderBy(u=>u.FullName).ToListAsync();
        }

        public async Task<User> GetUser(string UserName)
        {
            var user = await _db.Users.Where(u => u.UserName == UserName).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Unable to find user {UserName}");
            }
            return user;
        }
    }
}
