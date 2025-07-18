using Microsoft.AspNetCore.Mvc;
using PostgramAPI.Data;

namespace PostgramAPI.Controllers;
[ApiController]
[Route("api/[controller]")]


public class PostController : ControllerBase
{
    private readonly PostgramDbContext _context;

    public PostController(PostgramDbContext context)
    {
        _context = context;
    }
    
    /*[HttpPost]*/
    
    
}