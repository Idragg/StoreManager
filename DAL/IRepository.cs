using StoreManager.Domain;

namespace StoreManager.DAL;

public interface IRepository
{
    public IEnumerable<Product> ReadAllProducts();
}