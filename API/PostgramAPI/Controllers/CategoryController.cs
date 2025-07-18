using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly PostgramDbContext _context;

    public CategoryController(PostgramDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _context.Categories
            .Select(n => new CategoryDto()
            {
                Id = n.Id,
                Name = n.Name
            }).ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync<Category>(c=>c.Id == id);
        return Ok(category);
    }
}