using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Helpers;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class AuthServices : IAuthServices
{
    private readonly IConfiguration _configuration;
    private readonly PostgramDbContext _context;
    private readonly PasswordHelper _passwordHelper;
    private readonly UserManager<Auth> _userManager;
    private readonly SignInManager<Auth> _signInManager;


    public AuthServices(IConfiguration configuration, PostgramDbContext context,
        PasswordHelper passwordHelper,
        UserManager<Auth> userManager,
        SignInManager<Auth> signInManager)
    {
        _configuration = configuration;
        _context = context;
        _passwordHelper = passwordHelper;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<string> Login(LoginDto login)
    {
        var user = await _userManager.FindByNameAsync(login.UserName);

        Console.WriteLine(user.UserName);

        var result = await _signInManager.CheckPasswordSignInAsync(
            user, login.Password, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return _passwordHelper.GenerateToken(user.UserName);
        }

        return null;
    }
}