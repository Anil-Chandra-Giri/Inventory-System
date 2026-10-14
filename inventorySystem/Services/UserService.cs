using Azure.Core;
using inventorySystem.Data;
using inventorySystem.Dtos.Users;
using inventorySystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _db;
        private readonly IPasswordHasher<User> _hasher;
        public UserService (AppDbContext db, IPasswordHasher<User> hasher)
        {  _db = db;
           _hasher = hasher;
        }

        public async Task<User> CreateUser (CreateUserDto dto)
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

            var User = new User
            {
                UserID = Guid.NewGuid().ToString(),
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.UserName,
                RoleID = dto.RoleID,
            };
            User.PasswordHash = _hasher.HashPassword(User, dto.Password);
            _db.Users.Add(User);
            await _db.SaveChangesAsync();

            return User;
        }
    }
}
