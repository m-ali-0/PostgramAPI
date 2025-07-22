namespace PostgramAPI.DTOs;

public class CreatePostRequest
{
    public string Content { get; set; }
    public string? Title { get; set; }
    public List<int> CategoryIds { get; set; }
    
}