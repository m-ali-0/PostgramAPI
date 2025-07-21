using PostgramAPI.Models;

namespace PostgramAPI.DTOs;

public class PostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<CategoryDto2> Categories { get; set; }
    public string DisplayName { get; set; }
    
    

    /*public string UserName { get; set; }*/
}