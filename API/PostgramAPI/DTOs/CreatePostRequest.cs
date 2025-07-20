using PostgramAPI.Models;

namespace PostgramAPI.DTOs;

public class CreatePostRequest
{
    public string PostURL { get; set; }

    public ICollection<Category> Categories { get; set; }
}