using HashLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;
using Microsoft.AspNetCore.Identity;
using PostgramAPI.Services;

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
            Bio = request.Bio,
            Age = request.Age,
            ProfilePic = request.ProfilePic,
            Auth = new Auth()
            {
                Email = request.Email,
                PasswordHash = AuthServices.HassPassword(request.Password),
                UserName = request.Username
            }
        };
        _context.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _context.Users
            .Select(n => new UsersDto()
            {
                DisplayName = n.DisplayName,
                ProfilePic = n.ProfilePic
            }).ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _context.Users
            .Where(n => n.Id == id)
            .Select(n => new UserDto()
            {
                Age = n.Age,
                DisplayName = n.DisplayName,
                ProfilePic = n.ProfilePic,
                Bio = n.Bio,
                UserName = n.Auth.UserName
            }).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }
}