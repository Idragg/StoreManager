using StoreManager.BL.Domain;

namespace StoreManager.DAL;

public interface IRepository
{
    public IEnumerable<Product> ReadAllProducts();
    public IEnumerable<Category> ReadAllCategories();
    public IEnumerable<StoreProduct> ReadAllStoreProducts();
}