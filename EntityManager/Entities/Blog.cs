namespace EntityManager.Entities;

public class Blog:BaseEntity<int>
{
    public string Url { get; set; }

    public ICollection<Post> Posts { get; set; }
}