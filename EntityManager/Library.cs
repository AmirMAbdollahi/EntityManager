namespace EntityManager;

public class Library:BaseEntity<int>
{
    public string Name { get; set; }
    public string Address { get; set; }

    public ICollection<Book> Books { get; set; }
}