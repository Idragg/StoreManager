using StoreManager.BL.Domain;

namespace StoreManager.DAL.BL;

public class WeightMeanPrice : IPriceStrategy
{
    private readonly IManager _manager;
    public WeightMeanPrice(IManager manager)
    {
        _manager = manager;
    }

    public double GetPrice(Category? category)
    {
        var weight = 0;
        var price = 0.0;

        foreach (var storeProduct in _manager.GetAllStoreProducts())
        {
            price += storeProduct.SellingPrice * storeProduct.Stock;
            weight += storeProduct.Stock;
        }

        return weight == 0 ? 0 : price / weight;
    }
}