namespace PostgramAPI.Models;

public class Post
{
    public int Id { get; set; }
    public string PostURL { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<PostCategoryRelation> PostCategoryRelations { get; set; }
}