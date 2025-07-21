using System.Text.Json.Serialization;

namespace PostgramAPI.Models;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }


    public int UserId { get; set; }
    [JsonIgnore] public User User { get; set; }

    public List<PostCategoryRelation> PostCategoryRelations { get; set; }
}