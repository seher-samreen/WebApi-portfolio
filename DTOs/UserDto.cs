namespace PortfolioManagementApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }               // Optional
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";  // ✅ Required for registration
        public string Role { get; set; } = "User";  // Optional
    }
}
