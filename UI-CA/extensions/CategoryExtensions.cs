using StoreManager.BL.Domain;

namespace StoreManager.UI.CA.extensions;

public static class CategoryExtensions
{
    public static string InfoText(this Category category)
    {
        
        return $"{category.Name} | Description: {category.Description} | Products: {category.Products}";
    }
}