using Microsoft.AspNetCore.Mvc;
using PostgramAPI.Data;
using PostgramAPI.Models;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly PostgramDbContext _context;

    public UserController(PostgramDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ICollection<User> Get()
    {
        
    }
}