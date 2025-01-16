using api.Helpers;
using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authenticationService.LoginAsync(loginDto.Username, loginDto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = JwtTokenGenerator.GenerateToken(
                user.NomUtilisateur,
                user.Role,
                _configuration["Jwt:Key"]
            );

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authenticationService.RegisterAsync(registerDto.Username, registerDto.Password, registerDto.Role);

            if (!result)
                return BadRequest("Registration failed");

            return Ok("User registered successfully");
        }
    }
}
