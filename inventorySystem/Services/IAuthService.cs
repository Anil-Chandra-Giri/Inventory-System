using static inventorySystem.Dtos.Auth.AuthDto;

namespace inventorySystem.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginDto dto);
    }
}
