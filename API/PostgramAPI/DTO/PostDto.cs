namespace PostgramAPI.DTOs;

public class PostDto
{
    public string? Title { get; set; }
    public string Content { get; set; }
    public List<CategoryDto> Categories { get; set; }
    public string? DisplayName { get; set; }
}