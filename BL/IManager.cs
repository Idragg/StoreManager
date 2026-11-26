using StoreManager.BL.Domain;

namespace StoreManager.DAL.BL;

public interface IManager
{
    public IEnumerable<Product> GetAllProducts();
    public IEnumerable<Category> GetAllCategories();
    public IEnumerable<StoreProduct> GetAllStoreProducts();
}