namespace PostgramAPI.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<PostCategoryRelation> PostCategoryRelations { get; set; }
}