using StoreManager.BL.Domain;

namespace StoreManager.DAL.BL;

public interface IPriceStrategy
{
    public double GetPrice(Category? category);
}