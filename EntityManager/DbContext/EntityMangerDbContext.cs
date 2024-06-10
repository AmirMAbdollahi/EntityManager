using EntityManager.Entities;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Library)
            .WithMany(l => l.Books)
            .HasForeignKey(a => a.LibraryId);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(a => a.Age)
                .IsRequired();
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(l => l.Address)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(b => b.Library)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LibraryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });
    }
}