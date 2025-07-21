using System.ComponentModel.DataAnnotations;

namespace PostgramAPI.DTOs;

public class CreatePostRequest
{
    public string Content { get; set; }
    public string Title { get; set; }
    public List<string> Categories { get; set; }
    [Required]
    public int UserId { get; set; }
}