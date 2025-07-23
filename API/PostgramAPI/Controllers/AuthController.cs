using Microsoft.AspNetCore.Mvc;
using PostgramAPI.DTOs;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateAuth([FromBody] CreateAuthRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _authService.Create(request);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var token = await _authService.Login(login);
        if (token == null) return Unauthorized("Invalid username or password");

        return Ok(new { token });
    }
}