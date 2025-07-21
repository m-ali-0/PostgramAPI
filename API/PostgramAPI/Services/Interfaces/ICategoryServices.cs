using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public interface ICategoryServices
{
    Task<CategoryDto> GetCategoryById(int id);


    Task<List<CategoryDto>> GetAllCategories();


}