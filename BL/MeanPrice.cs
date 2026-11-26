namespace StoreManager.DAL.BL;

public class MeanPrice : IPriceStrategy
{
    private readonly IManager _manager;
    public MeanPrice(IManager manager)
    {
        _manager = manager;
    }

    public double GetPrice()
    {
        double price = 0;
        int count = 0;
        foreach (var product in _manager.GetAllProducts())
        {
            price += product.Price;
            count++;
        }

        return count == 0 ? 0 : price / count;
    }
}