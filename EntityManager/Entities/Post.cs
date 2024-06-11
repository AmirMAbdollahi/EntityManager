namespace EntityManager.Entities;

public class Post : BaseEntity<int>
{
    public string PictureUrl { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}