using HashLibrary;
using Microsoft.AspNetCore.Mvc;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;
using Microsoft.AspNetCore.Identity;
namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly PostgramDbContext _context;

    public UserController(PostgramDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        var hasher = new PasswordHasher<User>();
        var user = new User()
        {
            DisplayName = request.DisplayName,
            Bio = request.Bio
        };
        var auth = new Auth()
        {
            PasswordHash = hasher.HashPassword(user, request.Password),
            UserName = request.Username
        };
        user.Auth = auth;
        _context.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }
}