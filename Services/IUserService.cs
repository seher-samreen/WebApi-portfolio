using PortfolioManagementApi.DTOs;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Services
{
    public interface IUserService
    {
        string? Authenticate(LoginRequestDto loginRequest);
        Task<UserDto?> RegisterAsync(UserDto userDto); // ✅ Add this line
    }
}
