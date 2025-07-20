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
    private readonly UserServices _userServices;

    public UserController(UserServices userServices)
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