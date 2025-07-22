using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Helpers;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class UserService : IUserService
    
{
    private readonly PostgramDbContext _context;
    private readonly UserManager<Auth> _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger<IUserService> _logger;

    public UserService(
        PostgramDbContext context, 
        UserManager<Auth> userManager,
        IMapper mapper,
        ILogger<IUserService> logger)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<User> PostUser(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserDetails(CreateUserRequest request, int userId)
    {
        _logger.LogInformation("Updating User Details at {time}",  DateTime.Now);
        var user = await _context.Users.FindAsync(userId);
        user = _mapper.Map(request,user);
        _context.Users.Update(user!);
        _context.SaveChanges();
        return user;
    }

    public async Task<List<UsersDto>> GetAllUsers()
    {
        var users = await _context.Users
            .ToListAsync();
        return _mapper.Map<List<UsersDto>>(users);
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _context.Users
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();
        return _mapper.Map<UserDto>(user);;
    }
}