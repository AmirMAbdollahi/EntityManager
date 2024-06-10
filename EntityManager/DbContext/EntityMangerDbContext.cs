namespace EntityManager.DbContext;

using Microsoft.EntityFrameworkCore;

public class EntityMangerDbContext : DbContext
{
    public EntityMangerDbContext()
    {
    }

    public EntityMangerDbContext(DbContextOptions<EntityMangerDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=localhost;database=EntityManger;user=sa;password=yourStrong(!)Password;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Library> Libraries { get; set; }
}