using System.Text.Json.Serialization;

namespace PostgramAPI.Models;

public class PostCategoryRelation
{
    public int PostId { get; set; }
    [JsonIgnore] public Post Post { get; set; }
    public int CategoryId { get; set; }
    [JsonIgnore] public Category Category { get; set; }
}