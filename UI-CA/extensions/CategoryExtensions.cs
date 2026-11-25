using StoreManager.Domain;

namespace StoreManager.UI.CA.extensions;

public static class CategoryExtensions
{
    public static string InfoText(this Category category)
    {
        var products = string.Join(", ", category.Products.Select(p => p.Name));

        return $"{category.Name} | Description: {category.Description} | Products: {products}";
    }
}