using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public interface ICategoryService
{
    Task<CategoryDto> GetCategoryById(int id);


    Task<List<CategoryDto>> GetAllCategories();
}