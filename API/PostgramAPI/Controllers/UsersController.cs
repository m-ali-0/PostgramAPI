using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostgramAPI.DTOs;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
        {
            return Unauthorized("Unauthorized");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = int.Parse(claim.Value);
        _userService.UpdateUserDetails(request, userId);
        return Ok("User details updated");
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);
        return Ok(user);
    }
}