using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PostgramAPI.Data;

namespace PostgramAPI.Services;

public class AuthServices
{
    private readonly IConfiguration _configuration;
    private readonly PostgramDbContext _context;

    public AuthServices(IConfiguration configuration, PostgramDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }
    public static string HassPassword(string password)
    {
        return Convert.ToBase64String(System
            .Text.Encoding.UTF8.GetBytes(password));
    }

    public static string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };
        var key = new SymmetricSecurityKey(Encoding
            .UTF8.GetBytes(_configuration["Tokens:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer:  _configuration["Tokens:Issuer"],
            audience: _configuration["Tokens:Audience"],
            claims: claims,
            
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}