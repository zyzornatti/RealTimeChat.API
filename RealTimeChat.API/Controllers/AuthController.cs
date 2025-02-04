using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeChat.API.Interfaces;
using RealTimeChat.API.Models.Domain;
using RealTimeChat.API.Models.DTO;
using RealTimeChat.API.Services;

namespace RealTimeChat.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, ITokenService tokenService,IMapper mapper)
        {
            _authService = authService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userDetails)
        {
            var user = await _authService.LoginAsync(_mapper.Map<ApplicationUser>(userDetails));
            if(user == null)
            {
                return NotFound("Invalid username or password.");
            }

            var token = _tokenService.GenerateJwtToken(user);

            var response = new LoginResponseDto
            {
                JwtToken = token,
                Profile = _mapper.Map<UserDto>(user)
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto userDetails)
        {
            var details = await _authService.RegisterAsync(_mapper.Map<ApplicationUser>(userDetails));
            if (details != null)
            {
                return Ok(new
                {
                    message = "User registered successfully.",
                    user = _mapper.Map<UserDto>(details)
                });
            }

            return BadRequest();
        }

    }
}
