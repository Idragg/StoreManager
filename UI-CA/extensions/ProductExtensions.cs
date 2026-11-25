using StoreManager.Domain;

namespace StoreManager.UI.CA.extensions;

public static class ProductExtensions
{
    public static string InfoText(this Product product)
    {
        return $"Product {product.Name} | Category: {product.Category.Name} | " +
               $"Price: € {product.Price} | Amount in stock: {product.Stock}";
    }
}