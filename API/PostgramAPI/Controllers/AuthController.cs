using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly PostgramDbContext _context;

    public AuthController(IConfiguration configuration, PostgramDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Auth.UserName == login.UserName);
        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }
        
        var inputHash = AuthServices.HassPassword(login.Password);
        if (user.Auth.PasswordHash != inputHash)
        {
            return Unauthorized("Invalid username or password");
        }
        var token = AuthServices.GenerateToken(user.Auth.UserName);
    }
}