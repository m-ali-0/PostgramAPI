using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class UserServices
{
    private readonly PostgramDbContext _context;
    private readonly PasswordHelperServices _passwordHelperServices;

    public UserServices(PostgramDbContext context, PasswordHelperServices passwordHelperServices)
    {
        _context = context;
        _passwordHelperServices = passwordHelperServices;
    }

    public async Task<User> PostUser(CreateUserRequest request)
    {
        var user = new User()
        {
            DisplayName = request.DisplayName,
            Bio = request.Bio,
            Age = request.Age,
            ProfilePic = request.ProfilePic,
            Auth = new Auth()
            {
                Email = request.Email,
                PasswordHash = _passwordHelperServices.HassPassword(request.Password),
                UserName = request.Username
            }
        };
        _context.Add(user);
        _context.SaveChanges();
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