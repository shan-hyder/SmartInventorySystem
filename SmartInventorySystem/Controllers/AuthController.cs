using Microsoft.AspNetCore.Mvc;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Helpers;
using SmartInventorySystem.Interfaces;
using SmartInventorySystem.Services;

namespace SmartInventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
      
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO dto)
        {
            var result = await _authService.UserRegisterAsync(dto);
            if (result.success==true)
            {
                return Ok(new AuthResponseDTO
                {
                    success = true,
                    message = result.message
                });
            }
            return BadRequest(new AuthResponseDTO
            {
                success = false,
                message = result.message
            });   
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO dto)
        {
            var result = await _authService.UserLoginAsync(dto);
            if (result.success==true)
            {
                return Ok(result);
               
            }
            return Unauthorized(result);
        }
    }
}
