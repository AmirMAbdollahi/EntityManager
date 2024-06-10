namespace EntityManager;

public class Author : BaseEntity<int>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public ICollection<Book> Books { get; set; }
}