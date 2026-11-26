using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreManager.BL.Domain;

namespace StoreManager.DAL.EF;

public class StoreManagerDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<StoreProduct> StoreProducts { get; set; }

    public StoreManagerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(message => Debug.WriteLine(message),
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.StoreProducts)
            .WithOne(sp => sp.Product);

        modelBuilder.Entity<Store>()
            .HasMany(s => s.StoreProducts)
            .WithOne(sp => sp.Store);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category);
        
        modelBuilder.Entity<StoreProduct>()
            .HasKey("StoreId", "ProductId");
    }

    public bool CreateDatabase(bool dropDatabase)
    {
        if (dropDatabase) Database.EnsureDeleted();

        return Database.EnsureCreated();
    }
}