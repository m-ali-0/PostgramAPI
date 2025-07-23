using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public class UserService : IUserService

{
    private readonly PostgramDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<IUserService> _logger;

    public UserService(
        PostgramDbContext context,
        IMapper mapper,
        ILogger<IUserService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDto> UpdateUserDetails(UpdateUserRequest request, int userId)
    {
        _logger.LogInformation("Updating User Details at {time}", DateTime.Now);
        var user = await _context.Users.FindAsync(userId);
        user = _mapper.Map(request, user);
        _context.Users.Update(user);
        _context.SaveChanges();
        return _mapper.Map<UserDto>(user!);
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
        return _mapper.Map<UserDto>(user);
        ;
    }
}