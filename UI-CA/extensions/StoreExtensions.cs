using StoreManager.Domain;

namespace StoreManager.UI.CA.extensions;

public static class StoreExtensions
{
    public static string InfoText(this Store store)
    {
        var products = string.Join(", ", store.Products.Select(p => p.Name));
        var categories = string.Join(", ", store.Categories.Select(c => c.Name));

        return $"Store: {store.Name} | Products: {products} | Categories: {categories}";
    }
}