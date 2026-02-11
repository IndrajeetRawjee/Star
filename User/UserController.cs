using Microsoft.AspNetCore.Mvc;

namespace Star.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            await _userService.CreateUser(dto);
            return Ok($"{dto.FirstName} have been successfully registered");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var (isValid,token) = await _userService.ValidateUser(dto);
            await _userService.ValidateUser(dto);
            if (!isValid)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok($"{dto.Email} loggedIn and token = {token}");
        }
    }
}
