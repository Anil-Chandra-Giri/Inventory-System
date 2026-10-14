using inventorySystem.Data;
using inventorySystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static inventorySystem.Dtos.Auth.AuthDto;

namespace inventorySystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IPasswordHasher<User> _hasher;
        private readonly JwtSettings _jwt;

        public AuthService(AppDbContext db, IPasswordHasher<User> hasher, IOptions<JwtSettings> jwt)
        {
            _db = db;
            _hasher = hasher;
            _jwt = jwt.Value;
        }

        public async Task<LoginResponseDto> Login(LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName)
                ?? throw new InvalidOperationException("Invalid credentials.");

            var verify = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (verify == PasswordVerificationResult.Failed)
                throw new InvalidOperationException("Invalid credentials.");

            var roleId = user.RoleID;
            var role = await _db.Roles.FirstOrDefaultAsync(r => r.RoleID == roleId);
            if(role == null)
            {
                throw new InvalidOperationException("Role doesnot exist");
            }
            string roleName = role.RoleName;
            var expiresAt = DateTime.UtcNow.AddMinutes(_jwt.ExpiryMinutes);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.UserID),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.UserID),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Role, roleName),                
                new("fullName", user.FullName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds);

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expiresAt,
                UserID = user.UserID,
                UserName = user.UserName,
                FullName = user.FullName,
                Role = roleName
            };
        }
    
    }
}
