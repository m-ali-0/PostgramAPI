using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public class CategoryServices
{
    private readonly PostgramDbContext _context;

    public CategoryServices(PostgramDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        var category = await _context.Categories
            .Where(c => c.Id == id)
            .Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefaultAsync();
        return category;
    }

    public async Task<List<CategoryDto>> GetAllCategories()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
        return categories;
    }
}