using Microsoft.AspNetCore.Mvc;
using PostgramAPI.Services;

namespace PostgramAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryServices _categoryServices;

    public CategoryController(CategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _categoryServices.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _categoryServices.GetCategoryById(id);
        return Ok(category);
    }
}