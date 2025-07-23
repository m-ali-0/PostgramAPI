using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostgramAPI.Data;
using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly PostgramDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<ICategoryService> _logger;

    public CategoryService(
        PostgramDbContext context,
        IMapper mapper,
        ILogger<ICategoryService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        _logger.LogInformation("Getting category by id at {Time}", DateTime.Now);
        var category = await _context.Categories
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> GetAllCategories()
    {
        _logger.LogInformation("Getting all categories at {Time}", DateTime.Now);
        var categories = await _context.Categories
            .ToListAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}