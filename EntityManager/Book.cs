namespace EntityManager;

public class Book : BaseEntity<int>
{
    public string Name { get; set; }
    public int Price { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
    public int LibraryId { get; set; }
    public Library Library { get; set; }
}