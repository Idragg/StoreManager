using Microsoft.EntityFrameworkCore;
using StoreManager.BL.Domain;

namespace StoreManager.DAL.EF;

public class Repository : IRepository
{
    private readonly StoreManagerDbContext _context;

    public Repository(StoreManagerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> ReadAllProducts()
    {
        return _context.Products
            .Include(p => p.Category)
            .ToList();
    }

    public IEnumerable<Category> ReadAllCategories()
    {
        return _context.Categories
            .ToList();
    }

    public IEnumerable<StoreProduct> ReadAllStoreProducts()
    {
        return _context.StoreProducts.
            Include(sp => sp.Product)
            .ToList();
    }
}