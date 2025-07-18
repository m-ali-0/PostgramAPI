using System.Text.Json.Serialization;

namespace PostgramAPI.Models;

public class Auth
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
}