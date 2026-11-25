using StoreManager.Domain;

namespace StoreManager.DAL.BL;

public interface IManager
{
    public IEnumerable<Product> GetAllProducts();
}