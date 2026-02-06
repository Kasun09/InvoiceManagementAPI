using Microsoft.AspNetCore.Mvc;
using InvoiceManagementAPI.DTOs;
using InvoiceManagementAPI.Services;

namespace InvoiceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.Register(dto);
            return result ? Ok("User Registered Successfully") : BadRequest("Registration Failed");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.Login(dto);
            if (token == null) return Unauthorized("Invalid credentials");
            return Ok(new { Token = token });
        }
    }
}