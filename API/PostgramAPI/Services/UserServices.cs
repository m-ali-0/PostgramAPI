using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Helpers;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class UserServices : IUserServices
    
{
    private readonly PostgramDbContext _context;
    private readonly PasswordHelper _passwordHelper;
    private readonly PasswordHasher<Auth> _hasher;
    private readonly UserManager<Auth> _userManager;

    public UserServices(PostgramDbContext context, PasswordHelper passwordHelper, PasswordHasher<Auth> hasher, UserManager<Auth> userManager)
    {
        _context = context;
        _passwordHelper = passwordHelper;
        _hasher = hasher;
        _userManager = userManager;
    }

    public async Task<User> PostUser(CreateUserRequest request)
    {
        var user = new User
        {
            Bio = request.Bio,
            DisplayName = request.DisplayName,
            Age = request.Age,
            ProfilePic = request.ProfilePic
        };
        
        EntityEntry<User> newUser =_context.Users.Add(user);
        await _context.SaveChangesAsync();

        var auth = new Auth()
        {
            Email = request.Email,
            UserName = request.Username,
            User = newUser.Entity
        };
        
        var result = await _userManager.CreateAsync(auth, request.Password);

        if (result.Succeeded)
        {
            Logger<UserServices> logger = new Logger<UserServices>(new LoggerFactory());
            logger.LogInformation("User created");
        }
        return user;
    }

    public async Task<List<UsersDto>> GetUsers()
    {
        var users = await _context.Users
            .Select(n => new UsersDto()
            {
                DisplayName = n.DisplayName,
                ProfilePic = n.ProfilePic
            }).ToListAsync();
        return users;
    }

    public async Task<UserDto> GetUser(int id)
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
        return user;
    }
}