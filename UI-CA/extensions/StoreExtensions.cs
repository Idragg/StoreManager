using StoreManager.BL.Domain;

namespace StoreManager.UI.CA.extensions;

public static class StoreExtensions
{
    public static string InfoText(this Store store)
    {

        return $"Store: {store.Name} | Products: {store.StoreProducts} | Categories: {store.Categories}";
    }
}