using System.Text.Json.Serialization;

namespace PostgramAPI.Models;

public class User
{
    public int Id { get; set; }
    public string? DisplayName { get; set; }
    public string? Bio { get; set; }
    public int? Age { get; set; }
    public string? ProfilePic { get; set; }


    [JsonIgnore] public Auth Auth { get; set; }
    [JsonIgnore] public List<Post> Posts { get; set; }
}