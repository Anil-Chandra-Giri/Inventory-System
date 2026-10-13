using inventorySystem.Dtos.Users;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserDto dto);
    }
}
