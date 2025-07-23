using PostgramAPI.ValidationAttribute;

namespace PostgramAPI.DTOs;

public class CreatePostRequest
{
    [NotContaining("content", new string[] {"gay","badword"})] 
    public string Content { get; set; }
    
    [NotContaining("title", new string[]{"bad"})] 
    public string? Title { get; set; }
    public List<int> CategoryIds { get; set; }
}