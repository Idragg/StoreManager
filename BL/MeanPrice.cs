using StoreManager.BL.Domain;

namespace StoreManager.DAL.BL;

public class MeanPrice : IPriceStrategy
{
    private readonly IManager _manager;

    public MeanPrice(IManager manager)
    {
        _manager = manager;
    }

    public double GetPrice(Category? category)
    {
        double price = 0;
        int count = 0;

        foreach (var storeProduct in _manager.GetAllStoreProducts())
        {
            if (category == null || storeProduct.Product.Category.Id == category.Id)
            {
                price += storeProduct.SellingPrice;
                count++;
            }
        }
        return count == 0 ? 0 : price / count;
    }
}