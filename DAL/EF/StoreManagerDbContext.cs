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
    public DbSet<Order> Orders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

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

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Store)
            .WithMany(s => s.Orders);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Store)
            .WithMany(s => s.Employees);

        modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Products)
            .WithMany(o => o.Suppliers);


        modelBuilder.Entity<OrderLine>()
            .HasKey("OrderId", "ProductId");

        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderLines)
            .WithOne(ol => ol.Product);
        
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderLines)
            .WithOne(ol => ol.Order);
    }

    public bool CreateDatabase(bool dropDatabase)
    {
        if (dropDatabase) Database.EnsureDeleted();

        return Database.EnsureCreated();
    }
}