using SmartInventorySystem.Entities;

namespace SmartInventorySystem.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
