using System.Text.Json.Serialization;

namespace PostgramAPI.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore] public List<Post> Posts { get; set; }
    // public List<PostCategoryRelation> PostCategoryRelations { get; set; }
}