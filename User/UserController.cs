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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User newUser)
        {
            var user = await _userService.CreateUser(newUser);
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userService.GetUsers();
            return Ok(user);
        }
    }
}
