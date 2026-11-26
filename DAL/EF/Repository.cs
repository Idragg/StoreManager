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
        return _context.Products;
    }

    public IEnumerable<Category> ReadAllCategories()
    {
        return _context.Categories;
    }
}