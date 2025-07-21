using Microsoft.AspNetCore.Mvc;
using PostgramAPI.DTOs;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        var user = _userServices.PostUser(request);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userServices.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userServices.GetUser(id);
        return Ok(user);
    }
}