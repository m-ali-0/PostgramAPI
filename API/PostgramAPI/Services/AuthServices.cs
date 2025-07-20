using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PostgramAPI.Data;
using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public class AuthServices : IAuthServices
{
    private readonly IConfiguration _configuration;
    private readonly PostgramDbContext _context;
    private readonly PasswordHelperServices _passwordHelperServices;

    public AuthServices(IConfiguration configuration, PostgramDbContext context,
        PasswordHelperServices passwordHelperServices)
    {
        _configuration = configuration;
        _context = context;
        _passwordHelperServices = passwordHelperServices;
    }

    public async Task<string> Login(LoginDto login)
    {
        var user = await _context.Users
            .Include(n => n.Auth)
            .FirstOrDefaultAsync(n => n.Auth.UserName == login.UserName);
        Console.WriteLine(user.DisplayName);
        if (user == null || user.Auth == null || user.Auth.UserName == login.UserName)
        {
            throw new UnauthorizedAccessException("User not found");
        }

        var inputHash = _passwordHelperServices.HassPassword(login.Password);
        if (user.Auth.PasswordHash != inputHash)
        {
            throw new UnauthorizedAccessException("Invalid password");
        }

        return _passwordHelperServices.GenerateToken(user.Auth.UserName);
    }
}