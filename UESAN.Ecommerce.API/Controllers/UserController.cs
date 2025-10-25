using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email and password are required.");

            var user = await _userService.SignIn(request.Email, request.Password);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null || string.IsNullOrWhiteSpace(userCreateDTO.Email) || string.IsNullOrWhiteSpace(userCreateDTO.Password))
                return BadRequest("Email and password are required.");

            var id = await _userService.SignUp(userCreateDTO);
            if (id <= 0)
                return BadRequest("Unable to create user.");

            // Return location header pointing to the created resource (route not implemented for Get by id)
            return Created($"/api/user/{id}", new { Id = id });
        }
    }
}
