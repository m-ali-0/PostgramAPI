namespace PostgramAPI.Models;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }

    public List<Category> Categories { get; set; }
}