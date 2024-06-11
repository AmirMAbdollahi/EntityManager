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

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProduct { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Time).IsRequired(false).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnType("varchar");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(op => new { op.OrderId, op.ProductId });
            
            entity.HasOne(op => op.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(op => op.OrderId);

            entity.HasOne(op => op.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(op => op.ProductId);
        });
    }
}