using inventorySystem.Dtos.Users;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserDto dto);
        Task<User> UpdateUser(string UserName,UpdateUserDto dto);
        Task<User> ChangeRole(string UserName, ChangeRoleDto dto);
        Task<List<User>> GetAllUser();
        Task<User>GetUser(string UserName);
    }
}
