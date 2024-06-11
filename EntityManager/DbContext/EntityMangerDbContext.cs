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

    // public DbSet<Blog> Blogs { get; set; }
    // public DbSet<Post> Posts { get; set; }
    // public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Url).IsRequired().HasColumnType("varchar");
        });
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.PictureUrl).IsRequired(false).HasColumnType("varchar");
            entity.HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId);
        });
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Text).IsRequired().HasMaxLength(500).HasColumnType("Nvarchar");
            entity.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
        });
    }
}