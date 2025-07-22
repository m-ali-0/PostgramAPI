using Microsoft.AspNetCore.Identity;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Helpers;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public class AuthService : IAuthService
{
    private readonly PostgramDbContext _context;
    private readonly PasswordHelper _passwordHelper;
    private readonly UserManager<Auth> _userManager;
    private readonly SignInManager<Auth> _signInManager;
    private readonly ILogger<IAuthService> _logger;


    public AuthService(
        PostgramDbContext context,
        PasswordHelper passwordHelper,
        UserManager<Auth> userManager,
        SignInManager<Auth> signInManager,
        ILogger<IAuthService> logger)
    {
        _context = context;
        _passwordHelper = passwordHelper;
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }


    public async Task<Auth> Create(CreateAuthRequest request)
    {
        _logger.LogInformation("Creating new user at {time}", DateTime.Now);
        var user = new User();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        var auth = new Auth()
        {
            UserName = request.UserName,
            UserId = user.Id,
            User = user
        };
        
        

        var result = await _userManager.CreateAsync(auth, request.Password);
        _context.Auths.Add(auth);
        await _context.SaveChangesAsync();

        if (result.Succeeded)
        {
            _logger.LogInformation("Auth created");
        }

        return auth;
    }


    public async Task<string> Login(LoginDto login)
    {
        var auth = await _userManager.FindByNameAsync(login.UserName);

        _logger.LogInformation("Found username : {username}", auth.UserName);

        var result = await _signInManager.CheckPasswordSignInAsync(
            auth, login.Password, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            _logger.LogInformation("Token created at {time}", DateTime.Now);
            return _passwordHelper.GenerateToken(auth.UserName,auth.UserId);
        }

        return null;
    }
}