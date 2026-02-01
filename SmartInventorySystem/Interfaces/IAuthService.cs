using SmartInventorySystem.DTOs;

namespace SmartInventorySystem.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponseDTO> UserRegisterAsync(RegisterUserDTO dto);
        public Task<AuthResponseDTO> UserLoginAsync(LoginDTO dto);
    }
}
