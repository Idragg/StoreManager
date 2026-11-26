using StoreManager.Domain;

namespace StoreManager.DAL.BL;

public class WeightMeanPrice : IPriceStrategy
{
    private readonly IManager _manager;
    public WeightMeanPrice(IManager manager)
    {
        _manager = manager;
    }

    public double GetPrice()
    {
        var weight = 0;
        var price = 0.0;

        foreach (var product in _manager.GetAllProducts())
        {
            price += product.Price * product.Stock;
            weight += product.Stock;
        }

        return weight == 0 ? 0 : price / weight;
    }
}