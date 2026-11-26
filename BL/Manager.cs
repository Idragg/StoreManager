using StoreManager.BL.Domain;

namespace StoreManager.DAL.BL;

public class Manager : IManager
{
    private readonly IRepository _repository;
    public Manager(IRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        
        return _repository.ReadAllProducts();
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _repository.ReadAllCategories();
    }
}