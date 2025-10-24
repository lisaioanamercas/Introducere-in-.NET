using Microsoft.EntityFrameworkCore;
using ProductManagement.Features.Products;

namespace ProductManagement.Persistence;

public class ProductManagementContext(DbContextOptions<ProductManagementContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            
            entity.Property(e => e.Brand)
                .IsRequired()
                .HasMaxLength(100);
            
            entity.Property(e => e.SKU)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.HasIndex(e => e.SKU)
                .IsUnique();
            
            entity.Property(e => e.Price)
                .HasPrecision(18, 2);
            
            entity.Property(e => e.Category)
                .HasConversion<string>();
            
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500);
            
            entity.Property(e => e.CreatedAt)
                .IsRequired();
        });
    }
}