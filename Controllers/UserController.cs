using Microsoft.AspNetCore.Mvc;
using PortfolioManagementApi.DTOs;
using PortfolioManagementApi.Services;
using System.Threading.Tasks;

namespace PortfolioManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/User/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequest)
        {
            var token = _userService.Authenticate(loginRequest);
            if (token == null)
                return Unauthorized("Invalid username or password.");

            return Ok(new { Token = token });
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var createdUser = await _userService.RegisterAsync(userDto);
            if (createdUser == null)
                return BadRequest("Registration failed. Username may already exist.");

            return Ok(createdUser);
        }
    }
}
