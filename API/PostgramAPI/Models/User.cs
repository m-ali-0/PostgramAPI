namespace PostgramAPI.Models;

public class User
{
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public int Age { get; set; }
    public string ProfilePic { get; set; }


    public Auth Auth { get; set; }
    public ICollection<Post> Posts { get; set; }
}