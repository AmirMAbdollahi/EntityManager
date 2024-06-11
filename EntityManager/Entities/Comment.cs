namespace EntityManager.Entities;

public class Comment : BaseEntity<int>
{
    public string Text { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }
}